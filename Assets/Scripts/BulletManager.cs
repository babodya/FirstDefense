using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float speed = 0.1f;

    private Rigidbody bulletRigidbody;

    public float bulletPower = 10.0f;

    //GameObject targets;

    EnemyProperty enemyProperty;

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * 8f;

        Destroy(gameObject, 3f);
    }

    void Update()
    {
                
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemyProperty = other.GetComponent<EnemyProperty>();

            enemyProperty.TakeDamage(bulletPower);

            Destroy(gameObject);
        }
    }
}
