using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetecting : MonoBehaviour
{
    public List<GameObject> enemies;
    public TowerController towerController;
    void Start()
    {
        towerController = transform.parent.GetComponent<TowerController>();
    }

    void Update()
    {
        if (enemies.Count > 0)
        {
            if(enemies[0] == null)
            {
                enemies.RemoveAt(0);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if(towerController.targetEnemy == null)
                towerController.targetEnemy = other.gameObject;

            towerController.towerState = TowerController.TOWERSTATE.ATTACK;
            enemies.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            towerController.targetEnemy = null;
            //towerController.towerState = TowerController.TOWERSTATE.IDLE;
            enemies.Remove(other.gameObject);
        }
    }
}
