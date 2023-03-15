using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public int attackPower;
    public float attackCurTime;
    public float attackSpeed;
    public GameObject targetEnemy;
    public GameObject bulletPrefab;
    public GameObject muzzleEffect;

    public enum TOWERSTATE
    {
        IDLE = 0,
        ATTACK,
        UPGRADING,
        NONE
    }
    public TOWERSTATE towerState;
    public EnemyDetecting enemyDetecting;
    void Start()
    {
        towerState = TOWERSTATE.IDLE;
        enemyDetecting = GetComponentInChildren<EnemyDetecting>();
    }

    void Update()
    {
        switch (towerState)
        {
            case TOWERSTATE.IDLE:
                if(enemyDetecting.enemies.Count > 0 && targetEnemy == null)
                {
                    targetEnemy = enemyDetecting.enemies[0];
                    towerState = TOWERSTATE.ATTACK;
                }
                break;
            case TOWERSTATE.ATTACK:
                if (targetEnemy != null)
                {

                    transform.LookAt(targetEnemy.transform);
                    // 타워 x축 회전하지 않도록
                    Vector3 dir = transform.localRotation.eulerAngles;
                    dir.x = 0;
                    transform.localRotation = Quaternion.Euler(dir);
                    attackCurTime += Time.deltaTime;
                    if(attackCurTime > attackSpeed)
                    {
                        //Debug.Log("공격!!!!!!!!!!!!!!!!!!!!!!");
                        attackCurTime = 0;
                        GameObject bullet = Instantiate(bulletPrefab);
                        bullet.transform.position = transform.position;
                        bullet.GetComponent<BulletController>().target = targetEnemy;
                        bullet.GetComponent<BulletController>().bulletDamage = attackPower;
                    }
                }
                else
                {
                    attackCurTime = 0;

                    if (enemyDetecting.enemies.Count > 0)
                    {
                        targetEnemy = enemyDetecting.enemies[0];
                    }
                    else
                    {
                        towerState = TOWERSTATE.IDLE;
                    }
                }
                break;
            case TOWERSTATE.UPGRADING:
                break;
            case TOWERSTATE.NONE:
                break;
            default:
                break;
        }
    }
}
