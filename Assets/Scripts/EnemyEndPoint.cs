using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEndPoint : MonoBehaviour
{
    AudioSource playSound;

    [SerializeField]
    AudioClip music;

    // ÆøÆÈ ÇÁ¸®ÆÕ
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
        GameObject go = GameObject.Find("Life");

        GameManager gm = go.GetComponent<GameManager>();

        gm.SetHeart(gm.GetHeart() - 1);

        // pung ÇÁ¸®ÆÕ ¸¸µç´Ù.
        GameObject pungPung = Instantiate(pung);

        //»ó´ë¹æ gameobject ÆÄ±«
        Destroy(collision.gameObject);

        // point À§Ä¡¿¡ ³õ´Â´Ù.
        pungPung.transform.position = gameObject.transform.position;

        playSound.PlayOneShot(music);

        // 2ÃÊ ÈÄ ÆÄ±« ÀÌÆåÆ® ÆÄ±«
        Destroy(pungPung, 0.3f);
    }
}
