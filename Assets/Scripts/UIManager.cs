using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text killText;
    public Text lvText;
    public GameManager gameManager; 

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        killText.text = $"KILL: {gameManager.killCount}";
        lvText.text = $"LV {gameManager.currentLevel}";
    }

    public void RangeOff()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("AttackRange");
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
