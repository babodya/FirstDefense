using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // ���� ����
    Vector3 dir;

    void Start()
    {
        // �� ����Ʈ ã��
        GameObject endPoint = GameObject.Find("EndPoint");

        // ���ⱸ�ϱ� : ����Ʈ ���� (Point ������ - Enemy������) : ���� ����
        dir = endPoint.transform.position - transform.position;

        // ���� ũ�� ���� 1�� �����
        dir.Normalize();
    }

    void Update()
    {
        // �̵��ϱ� P = P0 +vt
        transform.position += dir * Time.deltaTime;

        //transform.position += dir * 8.0f * Time.deltaTime;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    // point�� �����ϸ� enemyObject �ı�
    //    Destroy(gameObject);
    //}
}
