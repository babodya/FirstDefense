using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonManager : MonoBehaviour
{
    // Bullet Prefab
    [SerializeField]
    GameObject bulletPrefabs;

    // ���� �ּҽð�
    public float spawnRateMin = 1.0f;
    
    // ���� �ִ�ð�
    public float spawnRateMax = 5.0f;

    // Ÿ��(��-Enemy)
    private GameObject targets;
    
    // Ÿ���� ��ġ
    private Transform targetTransform;

    // ���� �ּҽð�, �ִ�ð� ���̸� �������� �̾� ��� ��
    private float spawnRate;

    // ���� Ÿ�̸�
    private float timerAfterSpawn;

    // bullet ���ݷ�
    [SerializeField]
    float bulletPower = 10.0f;

    void Start()
    {
        // Ÿ�̸� �ʱ�ȭ
        timerAfterSpawn = 0f;
 
        // �ּ�, �ִ� ���� �ð� ���� ���� ���� �̱�
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    void Update()
    {
        // Enemy Tag�� ���� ��ü�� Ÿ������ ����
        targets = GameObject.FindGameObjectWithTag("Enemy");

        // Ÿ���� null ���� �ƴϸ�
        if (targets != null)
        {
            // EnemyMove script�� ���� ��ü�� ��ġ�� ������ �´�.
            targetTransform = FindObjectOfType<EnemyMove>().transform;

            // Ÿ�̸� parameter�� �ð� �Լ� �ο�
            timerAfterSpawn += Time.deltaTime;

            // Ÿ�̸��� �ð��� ���� �ð����� ũ��
            if (timerAfterSpawn >= spawnRate)
            {
                // Ÿ�̸Ӹ� �� �ʱ�ȭ
                timerAfterSpawn = 0;

                // bullet ��ü ����
                GameObject bullet = Instantiate(bulletPrefabs, transform.position, transform.rotation);

                // bullet�� rigidbody�� ���ݷ� �ο�
                bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletPower);

                // bullet�� ���ϴ� ��ġ�� Ÿ���� ��ġ��
                bullet.transform.LookAt(targetTransform);

                // �����ð� �� �ʱ�ȭ
                spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            }
        }
    }
}
