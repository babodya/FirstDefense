using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    // 총알 속도
    public float speed = 0.1f;

    // 총알 rigidbody
    private Rigidbody bulletRigidbody;

    // 총알 공격력
    public float bulletPower = 10.0f;

    // Enemy 속성
    EnemyProperty enemyProperty;

    void Start()
    {
        // 총알 rigidbody 컴포넌트 생성
        bulletRigidbody = GetComponent<Rigidbody>();

        // rigidbody를 사용하여 특정 속도로 날아갈수 있도록함
        bulletRigidbody.velocity = transform.forward * 8f;

        // 3초 후 오브젝트 파괴
        Destroy(gameObject, 3f);
    }

    // 충돌 시 처리 메소드
    private void OnTriggerEnter(Collider other)
    {
        // 충돌 객체가 "Enemy" 이면
        if (other.tag == "Enemy")
        {
            // Enemy 속성 객체를 들고온다.
            enemyProperty = other.GetComponent<EnemyProperty>();

            // Enemy 객체에 Bullet의 공격력 만큼 데미지를 준다.
            enemyProperty.TakeDamage(bulletPower);

            // bullet 객체 파괴
            Destroy(gameObject);
        }
    }
}
