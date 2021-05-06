using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //[SerializeField]
    //float defualtTime = 1.0f;

    //[SerializeField]
    //float maxTime = 10.0f;

    // 현재 시간
    [SerializeField]
    float currentTime = 0;

    // 일정 시간
    [SerializeField]
    float appearTime = 0f;

    [SerializeField]
    GameObject archerPrefab;

    [SerializeField]
    GameObject knightPrefab;

    [SerializeField]
    GameObject mageBlackPrefab;

    [SerializeField]
    GameObject zombiePrefab;

    string[] EnemyName = { "archer", "knight", "mageBlack", "zombie" };

    void Start()
    {

    }

    void Update()
    {
        int ranEnemyIdx = Random.Range(0, 4);

        currentTime += Time.deltaTime;

        if(currentTime > appearTime)
        {
            if (EnemyName[ranEnemyIdx] == "archer")
            {
                GameObject archer = Instantiate(archerPrefab);

                archer.transform.position = transform.position;
            }
            if (EnemyName[ranEnemyIdx] == "knight")
            {
                GameObject knight = Instantiate(knightPrefab);

                knight.transform.position = transform.position;
            }
            if (EnemyName[ranEnemyIdx] == "mageBlack")
            {
                GameObject mageBlack = Instantiate(mageBlackPrefab);

                mageBlack.transform.position = transform.position;
            }
            if (EnemyName[ranEnemyIdx] == "zombie")
            {
                GameObject zombie = Instantiate(zombiePrefab);

                zombie.transform.position = transform.position;
            }

            currentTime = 0;

            appearTime = 1.0f;
        }
    }
}
