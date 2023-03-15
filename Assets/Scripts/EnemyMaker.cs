using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaker : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float curTime = 0;
    public float coolTime = 2f;
    public int enemyCount = 0;
    public int enemyMaxCount = 10;

    public GameManager gameManager;

    public bool isRunning = false;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        isRunning = true;

    }


    // Update is called once per frame
    void Update()
    {
        if (enemyCount == enemyMaxCount)
        {
            isRunning = false;
        }

        if(isRunning)
        {
            curTime += Time.deltaTime;
            if (curTime > coolTime)
            {
                curTime = 0;
                GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
                enemy.name = $"Enemy_{enemyCount}";
                enemy.GetComponent<EnemyController>().enemyHp = gameManager.curEnemyHp;
                enemy.GetComponent<EnemyController>().moveSpeed = gameManager.curEnemySpeed;
                enemyMaxCount = gameManager.stageEnemyCount;
                enemyCount++;
            }
        }
    }

    public void InitEnemyMkaer()
    {
        enemyCount = 0;
        isRunning = true;
        gameManager.currentLevel++;
        gameManager.StageUp();
    }
}
