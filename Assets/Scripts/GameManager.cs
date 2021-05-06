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

    // �÷��̾� ��Ʈ(������)
    GameObject playerHeart;


    void Start()
    {
        bestScore = PlayerPrefs.GetInt("Best Score", 0);

        bestScoreTxt.text = "Best : " + bestScore;

        bestGold = PlayerPrefs.GetInt("Best Gold", 0);

        bestGoldTxt.text = "Best : " + bestGold;

        bestLevel = PlayerPrefs.GetInt("Best Level", 1);

        bestLevelTxt.text = "Best : " + bestLevel;

        playerHeartCount = 3;
    }

    void Update()
    {
        
    }

    public void SetScore(int value)
    {
        currentScore = value;

        // 4. UI Text�� current Score�� ǥ���Ѵ�.
        currentScoreTxt.text = "Score : " + currentScore;

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            bestScoreTxt.text = "Best : " + bestScore.ToString();
        }
    }

    public int GetScore()
    {
        return currentScore;
    }

    // ��ȭ Text
    public void SetGold(int value)
    {
        currentGold = value;

        // 4. UI Text�� current Score�� ǥ���Ѵ�.
        currentGoldTxt.text = "Gold : " + currentGold;

        if (currentGold > bestGold)
        {
            bestGold = currentGold;
            bestGoldTxt.text = "Best : " + bestGold.ToString();
        }
    }

    public int GetGold()
    {
        return currentGold;
    }

    // ���� Text
    public void SetLevel(int value)
    {
        currentLevel = value;

        // 4. UI Text�� current Level�� ǥ���Ѵ�.
        currentLevelTxt.text = "Tower Level : " + currentLevel;

        if (currentLevel > bestScore)
        {
            bestLevel = currentLevel;
            bestLevelTxt.text = "Best : " + bestLevel.ToString();
        }
    }

    public int GetLevel()
    {
        return currentLevel;
    }

    public void SetHeart(int value)
    {
        playerHeartCount = value;

        switch (playerHeartCount)
        {
            case 0:
                playerHeart = GameObject.Find("Heart_01");
                playerHeart.SetActive(false);
                GameOver();
                break;
            case 1:
                playerHeart = GameObject.Find("Heart_02");
                playerHeart.SetActive(false);
                break;
            case 2:
                playerHeart = GameObject.Find("Heart_03");
                playerHeart.SetActive(false);
                break;
            //case 3:
            //    GameOver();
            //    break;
        }
    }
    public int GetHeart()
    {
        return playerHeartCount;
    }

    public void GameOver()
    {
        Debug.Log("���� ��!");
        gameOverObj.SetActive(true);
    }
}
