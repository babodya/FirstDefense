using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyProperty : MonoBehaviour
{
    // �� �ӵ�
    public float enemySpeed = 5.0f;

    // �� �ִ� HP
    public float enemyMaxHp = 10.0f;

    // �� ���� Hp
    public float enemyCurrnentHp = 10.0f;
    
    // �� Gold
    public int enemyGlod = 100;

    // ü�¹�
    public Image healthBar;

    private bool isDead = false;

    private GameObject gameManagerObj;

    private GameManager gameManager;

    GameObject soundManager;

    SoundManager sm;

    private void Start()
    {
        gameManagerObj = GameObject.Find("GameManager");
        gameManager = gameManagerObj.GetComponent<GameManager>();

        soundManager = GameObject.Find("SoundManager");
        sm = soundManager.GetComponent<SoundManager>();
    }

    public void TakeDamage(float amount)
    {
        enemyCurrnentHp -= amount;

        healthBar.fillAmount = enemyCurrnentHp / enemyMaxHp;

        if(enemyCurrnentHp <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        sm.DieSound();

        gameManager.SetGold(gameManager.GetGold() + enemyGlod);

        gameManager.SetScore(gameManager.GetScore() + 1);

        Destroy(gameObject);
    }
}
