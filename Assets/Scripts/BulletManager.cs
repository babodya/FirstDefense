using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float speed = 0.1f;

    private Rigidbody bulletRigidbody;

    public float bulletPower = 10.0f;

    GameObject targets;

    public GameObject soundManager;

    SoundManager sm;

    void Start()
    {
        soundManager = GameObject.Find("SoundManager");

        sm = soundManager.GetComponent<SoundManager>();

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
            GameObject go = GameObject.Find("TextManager");

            GameManager gm = go.GetComponent<GameManager>();

            //playSound.PlayOneShot(music);
            //EnemyMove playerController = other.GetComponent<EnemyMove>();

            //Destroy(other.gameObject);

            //Destroy(gameObject);

            //if (playerController != null)
            //{
            //    playerController.Die();
            //}
            if (other.name == "archer(Clone)")
            {

                gm.SetScore(gm.GetScore() + 1);
                gm.SetGold(gm.GetGold() + 100);

                PlayerPrefs.SetInt("Best Score", gm.bestScore);
                PlayerPrefs.SetInt("Best Gold", gm.bestGold);

                sm.DieSound();

                Destroy(other.gameObject);

                Destroy(gameObject);
            }
            else if (other.name == "knight(Clone)")
            {
                gm.SetScore(gm.GetScore() + 1);
                gm.SetGold(gm.GetGold() + 100);

                PlayerPrefs.SetInt("Best Score", gm.bestScore);
                PlayerPrefs.SetInt("Best Gold", gm.bestGold);

                Destroy(other.gameObject);

                sm.DieSound();

                Destroy(gameObject);
            }
            else if (other.name == "mageDark(Clone)")
            {
                gm.SetScore(gm.GetScore() + 1);
                gm.SetGold(gm.GetGold() + 100);

                PlayerPrefs.SetInt("Best Score", gm.bestScore);
                PlayerPrefs.SetInt("Best Gold", gm.bestGold);

                Destroy(other.gameObject);

                sm.DieSound();

                Destroy(gameObject);
            }
            else if (other.name == "zombie(Clone)")
            {
                gm.SetScore(gm.GetScore() + 1);
                gm.SetGold(gm.GetGold() + 100);

                PlayerPrefs.SetInt("Best Score", gm.bestScore);
                PlayerPrefs.SetInt("Best Gold", gm.bestGold);

                Destroy(other.gameObject);

                sm.DieSound();

                Destroy(gameObject);
            }
        }
    }
}
