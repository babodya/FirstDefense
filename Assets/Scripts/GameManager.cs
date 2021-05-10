using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // ���� ���ھ�
    public int currentScore;

    // �ְ� ���ھ�
    public int bestScore;

    // ���� ��ȭ
    public int currentGold;

    // �ְ� ��ȭ
    public int bestGold;

    // ���� ����
    public int currentLevel;

    // �ְ� ����
    public int bestLevel;

    // �÷��̾� ��Ʈ ����
    public int playerHeartCount;

    // ���� ���ھ� Text
    [SerializeField]
    Text currentScoreTxt;

    // �ְ� ���ھ� Text
    [SerializeField]
    Text bestScoreTxt;

    // ���� ���� Text
    [SerializeField]
    Text currentLevelTxt;

    // �ְ� ���� Text
    [SerializeField]
    Text bestLevelTxt;

    // ���� ��ȭ Text
    [SerializeField]
    Text currentGoldTxt;

    // �ְ� ��ȭ Text
    [SerializeField]
    Text bestGoldTxt;

    // ���� ����
    [SerializeField]
    GameObject gameOverObj;

    // Buy Tower Button Text
    [SerializeField]
    Text buyTowerText;

    // �÷��̾� ��Ʈ(������-1)
    [SerializeField]
    GameObject playerHeart_1;

    // �÷��̾� ��Ʈ(������-2)
    [SerializeField]
    GameObject playerHeart_2;

    // �÷��̾� ��Ʈ(������-3)
    [SerializeField]
    GameObject playerHeart_3;


    void Start()
    {
        // ������Ʈ���� ���� �Ǿ��ִ� best socre ���� ��� �´�. ������ 0
        bestScore = PlayerPrefs.GetInt("Best Score", 0);

        // ���� best score ���� ȭ�鿡 �ѷ��ش�.
        bestScoreTxt.text = "Best : " + bestScore;

        // ������Ʈ���� ���� �Ǿ��ִ� best gold ���� ��� �´�. ������ 0
        bestGold = PlayerPrefs.GetInt("Best Gold", 0);

        // ���� best gold ���� ȭ�鿡 �ѷ��ش�.
        bestGoldTxt.text = "Best : " + bestGold;

        // ������Ʈ���� ���� �Ǿ��ִ� best level ���� ��� �´�. ������ 0
        bestLevel = PlayerPrefs.GetInt("Best Level", 1);

        // ���� best level ���� ȭ�鿡 �ѷ��ش�.
        bestLevelTxt.text = "Best : " + bestLevel;

        // player Heart �ʱ�ȭ
        playerHeartCount = 3;

    }

    // ���� ���� �޼ҵ�
    public void SetScore(int value)
    {
        // �޾ƿ� ������ ���� ������ �־� �ش�.
        currentScore = value;

        // 4. UI Text�� current Score�� ǥ���Ѵ�.
        currentScoreTxt.text = "Score : " + currentScore;

        // �ְ� �������� ���� ������ ������
        if (currentScore > bestScore)
        {
            // �ְ� ������ ���� ������ ����
            bestScore = currentScore;
            
            // ���� �� �ְ� ������ UI Text�� ǥ��
            bestScoreTxt.text = "Best : " + bestScore.ToString();
        }
    }

    // ���� ������ �����ش�.
    public int GetScore()
    {
        return currentScore;
    }

    // player gold ���� �޼ҵ�
    public void SetGold(int value)
    {
        // ���� ��� ����
        currentGold = value;

        // 4. UI Text�� current Score�� ǥ���Ѵ�.
        currentGoldTxt.text = "Gold : " + currentGold;

        // �ְ� ��� ���� ���� ��尡 �� ������
        if (currentGold > bestGold)
        {
            // �ְ� ��忡 ���� ��带 �־� �ش�.
            bestGold = currentGold;
            
            // �ְ� ��� UI Text�� ����
            bestGoldTxt.text = "Best : " + bestGold.ToString();
        }
    }

    // ���� ��带 ��������.
    public int GetGold()
    {
        // ���� ��� ��
        return currentGold;
    }

    // ���� ���� �޼ҵ�
    public void SetLevel(int value)
    {
        // ���� ���� �� ����
        currentLevel = value;

        // 4. UI Text�� current Level�� ǥ���Ѵ�.
        currentLevelTxt.text = "Tower Level : " + currentLevel;

        // �ְ� ������ ���� �������� ������
        if (currentLevel > bestScore)
        {
            // �ְ��� = ���緹��
            bestLevel = currentLevel;

            // �ְ� ���� Text�� ���� ����
            bestLevelTxt.text = "Best : " + bestLevel.ToString();
        }
    }

    // ������ �����ִ� �Լ�
    public int GetLevel()
    {
        // ���� ����
        return currentLevel;
    }

    // Player haert ���� �޼ҵ�
    public void SetHeart(int value)
    {
        // player�� ��Ʈ ���� ����
        playerHeartCount = value;

        // ���� �� ��Ʈ ������ ���� Action
        switch (playerHeartCount)
        {
            // ��Ʈ 1 -> 0 and GameOver �޼��� �޼ҵ� ȣ��
            case 0:
                playerHeart_1.SetActive(false);
                GameOver();
                break;
            
            // ��Ʈ 2 -> 1
            case 1:
                playerHeart_2.SetActive(false);
                break;

            // ��Ʈ 3 -> 2
            case 2:
                playerHeart_3.SetActive(false);
                break;
        }
    }

    // plalyer�� heart�� ������.
    public int GetHeart()
    {
        return playerHeartCount;
    }

    // ���� over�� �Ǿ��� ��� �����ٴ� Text ǥ��
    public void GameOver()
    {
        Debug.Log("���� ��!");
        gameOverObj.SetActive(true);
    }

    // Buy Tower Button Text ���� �޼ҵ�
    public void SetbuttonText(int value)
    {
        buyTowerText.text = "Buy Tower (" + value + "G)";
    }

}
