using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEndPoint : MonoBehaviour
{
    // gameManager 객체
    [SerializeField]
    GameObject gameManagerObj;

    // gameManager script
    GameManager gameManager;

    // 폭팔 프리팹
    public GameObject pung;

    // soundManager 객체
    [SerializeField]
    GameObject soundManagerObj;

    // gameManager script
    SoundManager soundManager;

    void Start()
    {
        // gameManager 객체 생성
        gameManager = gameManagerObj.GetComponent<GameManager>();

        // soundManager 객체 생성
        soundManager = soundManagerObj.GetComponent<SoundManager>();
    }

    // 충돌 발생시
    private void OnCollisionEnter(Collision collision)
    {
        // player 하트 - 1개
        gameManager.SetHeart(gameManager.GetHeart() - 1);

        // pung 프리팹 만든다.
        GameObject pungPung = Instantiate(pung);

        //상대방 gameobject 파괴
        Destroy(collision.gameObject);

        // point 위치에 놓는다.
        pungPung.transform.position = gameObject.transform.position;

        // SoundManager에 정의 해놓은 으악 소리 호출
        soundManager.DieSound();

        // 2초 후 파괴 이펙트 파괴
        Destroy(pungPung, 0.3f);
    }
}
