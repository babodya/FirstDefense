using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // 방향 변수
    Vector3 dir;

    void Start()
    {
        // 끝 포인트 찾기
        GameObject endPoint = GameObject.Find("EndPoint");

        // 방향구하기 : 포인트 방향 (Point 포지션 - Enemy포지션) : 방향 벡터
        dir = endPoint.transform.position - transform.position;

        // 방향 크기 벡터 1로 만들기
        dir.Normalize();
    }

    void Update()
    {
        // 이동하기 P = P0 +vt
        transform.position += dir * Time.deltaTime;

        //transform.position += dir * 8.0f * Time.deltaTime;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    // point에 도달하면 enemyObject 파괴
    //    Destroy(gameObject);
    //}
}
