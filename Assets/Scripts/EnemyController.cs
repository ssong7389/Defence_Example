using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
    public class EnemyController : MonoBehaviour
{
    public List<Transform> targetPos;
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

        if (SceneManager.GetActiveScene().name == "TowerMain")
        {
            for (int i = 1; i < 10; i++)
            {
                targetPos.Add(GameObject.Find($"EnemyNode{i}").transform);
            }
        }
        else if (SceneManager.GetActiveScene().name == "TowerMain_NavMesh")
        {
            nav = GetComponent<NavMeshAgent>();
            curTargetPos = GameObject.Find("Destroyer").transform;
            nav.SetDestination(curTargetPos.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "TowerMain")
        {
            curTargetPos = targetPos[0];
            float distance = Vector3.Distance(transform.position, curTargetPos.position);
            Vector3 dir = curTargetPos.position - transform.position;
            dir.y = 0;
            dir.Normalize();
            characterController.SimpleMove(dir * moveSpeed);

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
            if (distance < 0.2f)
            {
                targetPos.RemoveAt(0);
            }
        }

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
