using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonManager : MonoBehaviour
{
    // Bullet Prefab
    [SerializeField]
    GameObject bulletPrefabs;

    // 생성 최소시간
    public float spawnRateMin = 1.0f;
    
    // 생성 최대시간
    public float spawnRateMax = 5.0f;

    // 타켓(적-Enemy)
    private GameObject targets;
    
    // 타켓의 위치
    private Transform targetTransform;

    // 생성 최소시간, 최대시간 사이를 랜덤으로 뽑아 담는 곳
    private float spawnRate;

    // 생성 타이머
    private float timerAfterSpawn;

    // bullet 공격력
    [SerializeField]
    float bulletPower = 10.0f;

    void Start()
    {
        // 타이머 초기화
        timerAfterSpawn = 0f;
 
        // 최소, 최대 생성 시간 사이 랜덤 숫자 뽑기
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    void Update()
    {
        // Enemy Tag를 가진 객체를 타겟으로 지정
        targets = GameObject.FindGameObjectWithTag("Enemy");

        // 타겟이 null 값이 아니면
        if (targets != null)
        {
            // EnemyMove script를 가진 객체의 위치를 가지고 온다.
            targetTransform = FindObjectOfType<EnemyMove>().transform;

            // 타이머 parameter에 시간 함수 부여
            timerAfterSpawn += Time.deltaTime;

            // 타이머의 시간이 생성 시간보다 크면
            if (timerAfterSpawn >= spawnRate)
            {
                // 타이머를 재 초기화
                timerAfterSpawn = 0;

                // bullet 객체 생성
                GameObject bullet = Instantiate(bulletPrefabs, transform.position, transform.rotation);

                // bullet의 rigidbody에 공격력 부여
                bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletPower);

                // bullet이 향하는 위치를 타켓의 위치로
                bullet.transform.LookAt(targetTransform);

                // 생성시간 재 초기화
                spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            }
        }
    }
}
