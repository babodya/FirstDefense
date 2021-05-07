using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{

    Dictionary<int, TowerList> towerList;

    private int needMoney = 500;

    //private int count = 0;
    //int [] deleteTower;

    public GameObject failObj;

    FailManager failM;

    void Start()
    {
        towerList = new Dictionary<int, TowerList>();

        var d = FindObjectsOfType<TowerList>();

        for(int i = 0; i < d.Length; i++)
        {
            towerList.Add(i, d[i]);

            towerList[i].gameObject.SetActive(false);
        }

        int randomTower = Random.Range(0, towerList.Count);

        towerList[randomTower].gameObject.SetActive(true);

        towerList.Remove(randomTower);

        //deleteTower[0] = randomTower;

        //Debug.Log(towerList.Count.ToString());

        //for (int i = 0; i < towerList.Count; i++)
        //{
        //    Debug.Log(towerList[i].ToString());
        //}

        failM = failObj.GetComponent<FailManager>();
    }

    void Update()
    {

    }

    public void BuyTower()
    {
        GameObject tm = GameObject.Find("TextManager");

        GameManager gm = tm.GetComponent<GameManager>();

        GameObject bm = GameObject.Find("Buttons");

        GameManager bgm = bm.GetComponent<GameManager>();

        int gold = gm.GetGold();

        if(gold >= needMoney)
        {

            gm.SetGold(gold - needMoney);

            needMoney += 500;

            //buyTower button Text 변경
            bgm.SetbuttonText(needMoney);

            int randomTower = Random.Range(0, towerList.Count);

            try
            {
                towerList[randomTower].gameObject.SetActive(true);
            }
            catch (KeyNotFoundException e)
            {
                failObj.SetActive(true);

                Destroy(failObj, 2);
            }

            towerList.Remove(randomTower);
        }
        else
        {
            Debug.Log("아직 안돼!");
        }
    }

}
