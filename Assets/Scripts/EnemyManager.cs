using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // �ּ� �����ð�
    [SerializeField]
    float minTime = 0.5f;

    // �ִ� �����ð�
    [SerializeField]
    float maxTime = 3.0f;

    // ���� Ÿ�̸� �ð�
    [SerializeField]
    float currentTime = 0.0f;

    // ���� �ð�
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

    // Enemy�� �������� ���� �ϱ� ���� �迭
    string[] EnemyName = { "archer", "knight", "mageBlack", "zombie" };


    void Update()
    {
        // ���� �ð��� �ּ� �ð�, �ִ� �ð� ���� ���� ����.
        appearTime = Random.Range(minTime, maxTime);

        // ���� �� EnemyPrefab�� ���ڷ� �̴´�.
        int ranEnemyIdx = Random.Range(0, 4);

        // Ÿ�̸� �ð� �ο�
        currentTime += Time.deltaTime;

        // Ÿ�̸� �ð� ���� ���� �ð��� ũ��
        if(currentTime > appearTime)
        {
            // ���� �����Ǵ� Enemy��ü�� ��� ��
            GameObject currentObject = null;

            // ���� ���ڿ� �ش��ϴ� Enemy Prefab�� ã��.
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
            // Enemy ��ü ����
            GameObject enemy = Instantiate(currentObject);

            // Enemy ��ü ���� ��ġ
            enemy.transform.position = transform.position;

            // Ÿ�̸� �ʱ�ȭ
            currentTime = 0;

        }


    }
}
