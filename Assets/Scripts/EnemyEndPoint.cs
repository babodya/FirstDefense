using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEndPoint : MonoBehaviour
{
    AudioSource playSound;

    [SerializeField]
    AudioClip music;

    [SerializeField]
    GameObject gameManager;

    // ���� ������
    public GameObject pung;

    void Start()
    {
        playSound = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        GameManager gm = gameManager.GetComponent<GameManager>();

        gm.SetHeart(gm.GetHeart() - 1);

        // pung ������ �����.
        GameObject pungPung = Instantiate(pung);

        //���� gameobject �ı�
        Destroy(collision.gameObject);

        // point ��ġ�� ���´�.
        pungPung.transform.position = gameObject.transform.position;

        playSound.PlayOneShot(music);

        // 2�� �� �ı� ����Ʈ �ı�
        Destroy(pungPung, 0.3f);
    }
}
