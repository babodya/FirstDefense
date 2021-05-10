using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // 최소 생성시간
    [SerializeField]
    float minTime = 0.5f;

    // 최대 생성시간
    [SerializeField]
    float maxTime = 3.0f;

    // 생성 타이머 시간
    [SerializeField]
    float currentTime = 0.0f;

    // 생성 시간
    [SerializeField]
    float appearTime = 0.0f;

    // archer Prefab
    [SerializeField]
    GameObject archerPrefab;

    // knight Prefab
    [SerializeField]
    GameObject knightPrefab;

    // mageBlack Prefab
    [SerializeField]
    GameObject mageBlackPrefab;

    // zombie Prefab
    [SerializeField]
    GameObject zombiePrefab;

    // Enemy를 랜덤으로 생성 하기 위한 배열
    string[] EnemyName = { "archer", "knight", "mageBlack", "zombie" };


    void Update()
    {
        // 생성 시간에 최소 시간, 최대 시간 사이 값을 구함.
        appearTime = Random.Range(minTime, maxTime);

        // 생성 할 EnemyPrefab을 숫자로 뽑는다.
        int ranEnemyIdx = Random.Range(0, 4);

        // 타이머 시간 부여
        currentTime += Time.deltaTime;

        // 타이머 시간 보다 생성 시간이 크면
        if(currentTime > appearTime)
        {
            // 현재 생성되는 Enemy객체를 담는 곳
            GameObject currentObject = null;

            // 뽑은 숫자에 해당하는 Enemy Prefab을 찾음.
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
            // Enemy 객체 생성
            GameObject enemy = Instantiate(currentObject);

            // Enemy 객체 생성 위치
            enemy.transform.position = transform.position;

            // 타이머 초기화
            currentTime = 0;

        }


    }
}
