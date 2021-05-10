using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    // TowerManager script를 들고 있는 객체 
    [SerializeField]
    GameObject towerManager;

    // TowerManager script
    TowerManager tm;

    void Start()
    {
        // TowerManager 객체
        tm = towerManager.GetComponent<TowerManager>();
    }
    
    // BuyTower Button Onclick Action
    public void buttonAction()
    {
        // TowerManager Script의 타워 구입 메소드
        tm.BuyTower();
    }
}
