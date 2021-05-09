using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    List<TowerList> towerList;

    private int needMoney = 500;

    [SerializeField]
    GameObject gameManager;

    void Start()
    {
        towerList = new List<TowerList>();

        var d = FindObjectsOfType<TowerList>();

        for(int i = 0; i < d.Length; i++)
        {
            towerList.Add(d[i]);

            towerList[i].gameObject.SetActive(false);
        }
        int randomTower = Random.Range(0, towerList.Count);

        towerList[randomTower].gameObject.SetActive(true);

        towerList.Remove(towerList[randomTower]);
    }

    void Update()
    {

    }

    public void BuyTower()
    {
        GameManager gm = gameManager.GetComponent<GameManager>();

        int gold = gm.GetGold();

        if(gold >= needMoney)
        {
            gm.SetGold(gold - needMoney);

            needMoney += 500;

            //buyTower button Text 변경
            gm.SetbuttonText(needMoney);

            int randomTower = Random.Range(0, towerList.Count);

            towerList[randomTower].gameObject.SetActive(true);

            towerList.Remove(towerList[randomTower]);
        }
        else
        {
            Debug.Log("아직 안돼!");
        }
    }

}
