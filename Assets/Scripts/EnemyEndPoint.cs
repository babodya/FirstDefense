using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEndPoint : MonoBehaviour
{
    // gameManager ��ü
    [SerializeField]
    GameObject gameManagerObj;

    // gameManager script
    GameManager gameManager;

    // ���� ������
    public GameObject pung;

    // soundManager ��ü
    [SerializeField]
    GameObject soundManagerObj;

    // gameManager script
    SoundManager soundManager;

    void Start()
    {
        // gameManager ��ü ����
        gameManager = gameManagerObj.GetComponent<GameManager>();

        // soundManager ��ü ����
        soundManager = soundManagerObj.GetComponent<SoundManager>();
    }

    // �浹 �߻���
    private void OnCollisionEnter(Collision collision)
    {
        // player ��Ʈ - 1��
        gameManager.SetHeart(gameManager.GetHeart() - 1);

        // pung ������ �����.
        GameObject pungPung = Instantiate(pung);

        //���� gameobject �ı�
        Destroy(collision.gameObject);

        // point ��ġ�� ���´�.
        pungPung.transform.position = gameObject.transform.position;

        // SoundManager�� ���� �س��� ���� �Ҹ� ȣ��
        soundManager.DieSound();

        // 2�� �� �ı� ����Ʈ �ı�
        Destroy(pungPung, 0.3f);
    }
}
