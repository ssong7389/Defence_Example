using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentLevel = 1;
    public int curEnemyHp = 100;
    public float curEnemySpeed = 1f;
    public int stageEnemyCount = 2;
    public int killCount = 0;

    public void StageUp()
    {
        curEnemyHp *= 2;
        curEnemySpeed *= 1.1f;
        stageEnemyCount *= 2;
    }

}
