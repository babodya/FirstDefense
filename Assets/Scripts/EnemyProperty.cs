using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyProperty : MonoBehaviour
{
    // 적 속도
    public float enemySpeed = 5.0f;

    // 적 최대 HP
    public float enemyMaxHp = 10.0f;

    // 적 현재 Hp
    public float enemyCurrnentHp = 10.0f;
    
    // 적 Gold
    public int enemyGlod = 100;

    // Enemy 체력바
    public Image healthBar;

    // 죽었는지 판단
    private bool isDead = false;

    // GameManager 객체
    private GameObject gameManagerObj;

    // GameManager script
    private GameManager gameManager;

    // soundManager 객체
    GameObject soundManager;

    // soundManager script
    SoundManager sm;

    private void Start()
    {
        // GameManager 이름의 객체를 찾는다
        gameManagerObj = GameObject.Find("GameManager");

        // GameManager 객체가 들고 있는 GameManager script를 들고 온다.
        gameManager = gameManagerObj.GetComponent<GameManager>();

        // SoundManager 이름의 객체를 찾는다
        soundManager = GameObject.Find("SoundManager");

        // SoundManager 객체가 들고 있는 SoundManager script를 들고 온다.
        sm = soundManager.GetComponent<SoundManager>();
    }

    // Enemy에게 가해지는 데미지
    public void TakeDamage(float amount)
    {
        // Enemy의 현재 채력에서 받은 공격 만큼 차감
        enemyCurrnentHp -= amount;

        // 헬스바 이미지 비율 = 현재 체력 / 최대 체력(100% 체력)
        healthBar.fillAmount = enemyCurrnentHp / enemyMaxHp;

        // Enemy의 현재 체럭이 0보다 같거나 작고 and 이미 죽은 상태가 아니라면
        if(enemyCurrnentHp <= 0 && !isDead)
        {
            // Die 메소드 호출
            Die();
        }
    }

    // 죽었을때 구현 Action 메소드
    void Die()
    {
        // 죽은 상태로 변경
        isDead = true;

        // 으악 소리 호출
        sm.DieSound();

        // Player의 Gold를 죽은 에너미가 소유한 Gold 만큼 +
        gameManager.SetGold(gameManager.GetGold() + enemyGlod);

        // Player의 점수 + 1
        gameManager.SetScore(gameManager.GetScore() + 1);

        // Enemy객체 소멸
        Destroy(gameObject);
    }
}
