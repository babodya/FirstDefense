using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonManager : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefabs;

    public float spawnRateMin = 1.0f;
    public float spawnRateMax = 5.0f;

    private GameObject targets;
    private Transform targetTransform;

    private float spawnRate;
    private float timerAfterSpawn;

    [SerializeField]
    float bulletPower = 10.0f;

    Vector3 dir;

    void Start()
    {
        timerAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    void Update()
    {
        targets = GameObject.FindGameObjectWithTag("Enemy");

        if (targets != null)
        {
            targetTransform = FindObjectOfType<EnemyMove>().transform;

            timerAfterSpawn += Time.deltaTime;

            if (timerAfterSpawn >= spawnRate)
            {
                timerAfterSpawn = 0;

                GameObject bullet = Instantiate(bulletPrefabs, transform.position, transform.rotation);

                bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletPower);

                bullet.transform.LookAt(targetTransform);

                spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            }
        }
    }
}
