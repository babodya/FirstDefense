using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float speed = 5.0f;

    private Rigidbody bulletRigidbody;

    public float bulletPower = 10.0f;

    GameObject targets;


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

                Destroy(gameObject);
            }
            else if (other.name == "mageDark(Clone)")
            {
                gm.SetScore(gm.GetScore() + 1);
                gm.SetGold(gm.GetGold() + 100);

                PlayerPrefs.SetInt("Best Score", gm.bestScore);
                PlayerPrefs.SetInt("Best Gold", gm.bestGold);

                Destroy(other.gameObject);

                Destroy(gameObject);
            }
            else if (other.name == "zombie(Clone)")
            {
                gm.SetScore(gm.GetScore() + 1);
                gm.SetGold(gm.GetGold() + 100);

                PlayerPrefs.SetInt("Best Score", gm.bestScore);
                PlayerPrefs.SetInt("Best Gold", gm.bestGold);

                Destroy(other.gameObject);

                Destroy(gameObject);
            }
        }
    }
}
