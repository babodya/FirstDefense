using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    // �Ѿ� �ӵ�
    public float speed = 0.1f;

    // �Ѿ� rigidbody
    private Rigidbody bulletRigidbody;

    // �Ѿ� ���ݷ�
    public float bulletPower = 10.0f;

    // Enemy �Ӽ�
    EnemyProperty enemyProperty;

    void Start()
    {
        // �Ѿ� rigidbody ������Ʈ ����
        bulletRigidbody = GetComponent<Rigidbody>();

        // rigidbody�� ����Ͽ� Ư�� �ӵ��� ���ư��� �ֵ�����
        bulletRigidbody.velocity = transform.forward * 8f;

        // 3�� �� ������Ʈ �ı�
        Destroy(gameObject, 3f);
    }

    // �浹 �� ó�� �޼ҵ�
    private void OnTriggerEnter(Collider other)
    {
        // �浹 ��ü�� "Enemy" �̸�
        if (other.tag == "Enemy")
        {
            // Enemy �Ӽ� ��ü�� ���´�.
            enemyProperty = other.GetComponent<EnemyProperty>();

            // Enemy ��ü�� Bullet�� ���ݷ� ��ŭ �������� �ش�.
            enemyProperty.TakeDamage(bulletPower);

            // bullet ��ü �ı�
            Destroy(gameObject);
        }
    }
}
