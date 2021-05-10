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

    // Enemy ü�¹�
    public Image healthBar;

    // �׾����� �Ǵ�
    private bool isDead = false;

    // GameManager ��ü
    private GameObject gameManagerObj;

    // GameManager script
    private GameManager gameManager;

    // soundManager ��ü
    GameObject soundManager;

    // soundManager script
    SoundManager sm;

    private void Start()
    {
        // GameManager �̸��� ��ü�� ã�´�
        gameManagerObj = GameObject.Find("GameManager");

        // GameManager ��ü�� ��� �ִ� GameManager script�� ��� �´�.
        gameManager = gameManagerObj.GetComponent<GameManager>();

        // SoundManager �̸��� ��ü�� ã�´�
        soundManager = GameObject.Find("SoundManager");

        // SoundManager ��ü�� ��� �ִ� SoundManager script�� ��� �´�.
        sm = soundManager.GetComponent<SoundManager>();
    }

    // Enemy���� �������� ������
    public void TakeDamage(float amount)
    {
        // Enemy�� ���� ä�¿��� ���� ���� ��ŭ ����
        enemyCurrnentHp -= amount;

        // �ｺ�� �̹��� ���� = ���� ü�� / �ִ� ü��(100% ü��)
        healthBar.fillAmount = enemyCurrnentHp / enemyMaxHp;

        // Enemy�� ���� ü���� 0���� ���ų� �۰� and �̹� ���� ���°� �ƴ϶��
        if(enemyCurrnentHp <= 0 && !isDead)
        {
            // Die �޼ҵ� ȣ��
            Die();
        }
    }

    // �׾����� ���� Action �޼ҵ�
    void Die()
    {
        // ���� ���·� ����
        isDead = true;

        // ���� �Ҹ� ȣ��
        sm.DieSound();

        // Player�� Gold�� ���� ���ʹ̰� ������ Gold ��ŭ +
        gameManager.SetGold(gameManager.GetGold() + enemyGlod);

        // Player�� ���� + 1
        gameManager.SetScore(gameManager.GetScore() + 1);

        // Enemy��ü �Ҹ�
        Destroy(gameObject);
    }
}
