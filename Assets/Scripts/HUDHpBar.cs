using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDHpBar : MonoBehaviour
{
    public Transform target;
    public RectTransform canvas;
    public RectTransform hpBar;
    public Camera main;
    public GameObject hpBarPrefab;
    public GameObject hpObj;
    public int maxHp;
    EnemyController enemyController;

    void Start()
    {
        hpObj = Instantiate(hpBarPrefab);
        target = gameObject.transform;
        canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        hpObj.transform.SetParent(canvas);
        hpBar = hpObj.GetComponent<RectTransform>();
        hpBar.localPosition = Vector3.zero;
        hpBar.localScale = Vector3.one;
        hpBar.localRotation = Quaternion.Euler(0, 0, 0);
        main = Camera.main;
        enemyController = transform.parent.GetComponent<EnemyController>();
        maxHp = enemyController.enemyHp;
    }

   
    void Update()
    {
        Vector3 curPos = target.position;
        Vector2 screenPoint = main.WorldToScreenPoint(curPos);
        Vector2 canvasPos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, screenPoint, main, out canvasPos);

        if(hpBar != null)
        {
            hpBar.localPosition = canvasPos;
            hpBar.GetComponent<Slider>().value = (float)
                enemyController.enemyHp / maxHp;
        }
    }

    public void DestroyHpBar()
    {
        Destroy(hpBar.gameObject);
    }
}
