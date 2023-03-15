using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public GameObject upgradeTarget;
    
    public void AtkUp()
    {
        upgradeTarget.GetComponent<TowerController>().attackPower += 10;
    }
    public void AspUp()
    {
        if (upgradeTarget.GetComponent<TowerController>().attackSpeed > 0.25f)
            upgradeTarget.GetComponent<TowerController>().attackSpeed -= 0.05f;
    }
    public void ArgUp()
    {
        if (upgradeTarget.transform.GetChild(1).transform.localScale.x < 9)
            upgradeTarget.transform.GetChild(1).transform.localScale += new Vector3(0.5f, 0, 0.5f);
    }
}
