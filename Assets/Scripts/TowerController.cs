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
    ParticleSystem[] effects;
    public GameObject head;
    public float rotSpeed = 5f;
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
        effects = muzzleEffect.GetComponentsInChildren<ParticleSystem>();
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

                    head.transform.LookAt(targetEnemy.transform);
                    // 타워 x축 회전하지 않도록
                    Vector3 dir = head.transform.localRotation.eulerAngles;
                    //dir.x = 0;
                    head.transform.localRotation = Quaternion.Euler(dir);
                    attackCurTime += Time.deltaTime;
                    if(attackCurTime > attackSpeed)
                    {
                        //Debug.Log("공격!!!!!!!!!!!!!!!!!!!!!!");
                        attackCurTime = 0;
                        foreach (var eff in effects)
                        {
                            //eff.SetCustomParticleData
                        }
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
