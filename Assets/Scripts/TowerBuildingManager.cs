using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuildingManager : MonoBehaviour
{
    public GameObject TowerPrefab;
    public GameObject upgradePanel;
    public UpgradeManager upgradeManager;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (upgradePanel.activeSelf)
            return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                //Debug.Log($"Hit: {hit.collider.gameObject.tag}");
                switch (hit.collider.gameObject.tag)
                {
                    case "Block":
                        GameObject tower = Instantiate(TowerPrefab);
                        tower.transform.position = hit.collider.transform.position
                            + new Vector3(-0.5f, hit.collider.transform.localScale.y +0.25f, 0.5f);
                        break;
                    case "Block_None":
                        Debug.Log("타워 배치 불가");
                        break;
                    case "Tower":
                        //Debug.Log("Tower");
                        upgradePanel.SetActive(true);
                        upgradeManager.upgradeTarget = hit.collider.gameObject;
                        hit.collider.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
