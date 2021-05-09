using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    float minTime = 0.5f;

    [SerializeField]
    float maxTime = 3.0f;

    // 현재 시간
    [SerializeField]
    float currentTime = 0.0f;

    // 일정 시간
    [SerializeField]
    float appearTime = 0.0f;

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
        appearTime = Random.Range(minTime, maxTime);

        int ranEnemyIdx = Random.Range(0, 4);

        currentTime += Time.deltaTime;

        if(currentTime > appearTime)
        {
            GameObject currentObject = null;
            switch (EnemyName[ranEnemyIdx])
            {
                case "archer":

                    currentObject = archerPrefab;

                    break;

                case "knight":

                    currentObject = knightPrefab;

                    break;

                case "mageBlack":

                    currentObject = mageBlackPrefab;

                    break;

                case "zombie":

                    currentObject = zombiePrefab;

                    break;

            }
            GameObject enemy = Instantiate(currentObject);

            enemy.transform.position = transform.position;

            currentTime = 0;

            //appearTime = 3.0f;
        }


    }
}
