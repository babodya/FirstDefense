using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    GameObject towerManager;

    TowerManager tm;

    void Start()
    {
        tm = towerManager.GetComponent<TowerManager>();
    }
    
    public void buttonAction()
    {
        tm.BuyTower();
    }
}
