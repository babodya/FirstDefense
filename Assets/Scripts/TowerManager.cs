using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefabs;

    public float spawnRateMin = 1.0f;
    public float spawnRateMax = 1.0f;

    private GameObject targets;
    private Transform targetTransform;

    private float spawnRate;
    private float timerAfterSpawn;

    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        timerAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        //target = FindObjectOfType<EnemyMove>().transform;
        //target = GameObject.Find("archer2(Clone)").transform;

        //targets = GameObject.FindGameObjectWithTag("Enemy");

        //dir = targets.transform.position;// - transform.position;

        //dir.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        targets = GameObject.FindGameObjectWithTag("Enemy");
        //GameObject targets = GameObject.Find("archer(Clone)");

        if (targets != null)
        {
            targetTransform = FindObjectOfType<EnemyMove>().transform;

            timerAfterSpawn += Time.deltaTime;

            if (timerAfterSpawn >= spawnRate)
            {
                timerAfterSpawn = 0;
                GameObject bullet = Instantiate(bulletPrefabs, transform.position, transform.rotation);

                bullet.transform.LookAt(targetTransform);

                spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            }
        }
    }
}