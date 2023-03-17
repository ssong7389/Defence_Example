using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController_NavMesh : MonoBehaviour
{
    public Transform curTargetPos;

    public CharacterController characterController;

    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public int enemyHp = 100;
    private bool isDead = false;

    public GameManager gameManager;
    public GameObject deadEffect;
    public NavMeshAgent nav;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        characterController = GetComponent<CharacterController>();
        nav = GetComponent<NavMeshAgent>();
        curTargetPos = GameObject.Find("Destroyer").transform;
        nav.SetDestination(curTargetPos.position);
    }

    public void DamageByBullet(int dmg)
    {
        if (!isDead)
        {
            enemyHp -= dmg;
            if(enemyHp <= 0)
            {
                isDead = true;
                gameManager.killCount++;
                Instantiate(deadEffect, transform.position, transform.rotation);
                GetComponentInChildren<HUDHpBar>().DestroyHpBar();
                Destroy(gameObject);
            }
        }
    }
}
