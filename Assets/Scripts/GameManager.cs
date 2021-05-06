using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 현재 스코어
    public int currentScore;

    // 최고 스코어
    public int bestScore;

    // 현재 재화
    public int currentGold;

    // 최고 재화
    public int bestGold;

    // 현재 레벨
    public int currentLevel;

    // 최고 레벨
    public int bestLevel;

    // 플레이어 하트 갯수
    public int playerHeartCount;

    // 현재 스코어 Text
    [SerializeField]
    Text currentScoreTxt;

    // 최고 스코어 Text
    [SerializeField]
    Text bestScoreTxt;

    // 현재 레벨 Text
    [SerializeField]
    Text currentLevelTxt;

    // 최고 레벨 Text
    [SerializeField]
    Text bestLevelTxt;

    // 현재 재화 Text
    [SerializeField]
    Text currentGoldTxt;

    // 최고 재화 Text
    [SerializeField]
    Text bestGoldTxt;

    // 게임 오버
    [SerializeField]
    GameObject gameOverObj;

    // 플레이어 하트(라이프)
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

        // 4. UI Text에 current Score를 표시한다.
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

    // 재화 Text
    public void SetGold(int value)
    {
        currentGold = value;

        // 4. UI Text에 current Score를 표시한다.
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

    // 레벨 Text
    public void SetLevel(int value)
    {
        currentLevel = value;

        // 4. UI Text에 current Level를 표시한다.
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
        Debug.Log("게임 끝!");
        gameOverObj.SetActive(true);
    }
}
