using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    // TowerManager script�� ��� �ִ� ��ü 
    [SerializeField]
    GameObject towerManager;

    // TowerManager script
    TowerManager tm;

    void Start()
    {
        // TowerManager ��ü
        tm = towerManager.GetComponent<TowerManager>();
    }
    
    // BuyTower Button Onclick Action
    public void buttonAction()
    {
        // TowerManager Script�� Ÿ�� ���� �޼ҵ�
        tm.BuyTower();
    }
}
