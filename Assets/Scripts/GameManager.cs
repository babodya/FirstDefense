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

    // Buy Tower Button Text
    [SerializeField]
    Text buyTowerText;

    // 플레이어 하트(라이프-1)
    [SerializeField]
    GameObject playerHeart_1;

    // 플레이어 하트(라이프-2)
    [SerializeField]
    GameObject playerHeart_2;

    // 플레이어 하트(라이프-3)
    [SerializeField]
    GameObject playerHeart_3;


    void Start()
    {
        // 레지스트리에 저장 되어있는 best socre 값을 들고 온다. 없으면 0
        bestScore = PlayerPrefs.GetInt("Best Score", 0);

        // 들고온 best score 값을 화면에 뿌려준다.
        bestScoreTxt.text = "Best : " + bestScore;

        // 레지스트리에 저장 되어있는 best gold 값을 들고 온다. 없으면 0
        bestGold = PlayerPrefs.GetInt("Best Gold", 0);

        // 들고온 best gold 값을 화면에 뿌려준다.
        bestGoldTxt.text = "Best : " + bestGold;

        // 레지스트리에 저장 되어있는 best level 값을 들고 온다. 없으면 0
        bestLevel = PlayerPrefs.GetInt("Best Level", 1);

        // 들고온 best level 값을 화면에 뿌려준다.
        bestLevelTxt.text = "Best : " + bestLevel;

        // player Heart 초기화
        playerHeartCount = 3;

    }

    // 점수 변경 메소드
    public void SetScore(int value)
    {
        // 받아온 점수를 현재 점수에 넣어 준다.
        currentScore = value;

        // 4. UI Text에 current Score를 표시한다.
        currentScoreTxt.text = "Score : " + currentScore;

        // 최고 점수보다 현재 점수가 높으면
        if (currentScore > bestScore)
        {
            // 최고 점수를 현재 점수로 갱신
            bestScore = currentScore;
            
            // 갱신 된 최고 점수를 UI Text에 표시
            bestScoreTxt.text = "Best : " + bestScore.ToString();
        }
    }

    // 현재 점수를 보내준다.
    public int GetScore()
    {
        return currentScore;
    }

    // player gold 변경 메소드
    public void SetGold(int value)
    {
        // 현재 골드 변경
        currentGold = value;

        // 4. UI Text에 current Score를 표시한다.
        currentGoldTxt.text = "Gold : " + currentGold;

        // 최고 골드 보다 현재 골드가 더 많으면
        if (currentGold > bestGold)
        {
            // 최고 골드에 현재 골드를 넣어 준다.
            bestGold = currentGold;
            
            // 최고 골드 UI Text도 변경
            bestGoldTxt.text = "Best : " + bestGold.ToString();
        }
    }

    // 현재 골드를 내보낸다.
    public int GetGold()
    {
        // 현재 골드 값
        return currentGold;
    }

    // 레벨 변경 메소드
    public void SetLevel(int value)
    {
        // 현재 레벨 값 변경
        currentLevel = value;

        // 4. UI Text에 current Level를 표시한다.
        currentLevelTxt.text = "Tower Level : " + currentLevel;

        // 최고 레벨이 현재 레벨보다 높으면
        if (currentLevel > bestScore)
        {
            // 최고레벨 = 현재레벨
            bestLevel = currentLevel;

            // 최고 레벨 Text도 같이 변경
            bestLevelTxt.text = "Best : " + bestLevel.ToString();
        }
    }

    // 레벨을 보내주는 함수
    public int GetLevel()
    {
        // 현재 레벨
        return currentLevel;
    }

    // Player haert 변경 메소드
    public void SetHeart(int value)
    {
        // player의 하트 갯수 변경
        playerHeartCount = value;

        // 보유 한 하트 갯수에 따른 Action
        switch (playerHeartCount)
        {
            // 하트 1 -> 0 and GameOver 메세지 메소드 호출
            case 0:
                playerHeart_1.SetActive(false);
                GameOver();
                break;
            
            // 하트 2 -> 1
            case 1:
                playerHeart_2.SetActive(false);
                break;

            // 하트 3 -> 2
            case 2:
                playerHeart_3.SetActive(false);
                break;
        }
    }

    // plalyer의 heart를 보낸다.
    public int GetHeart()
    {
        return playerHeartCount;
    }

    // 게임 over가 되었을 경우 끝났다는 Text 표시
    public void GameOver()
    {
        Debug.Log("게임 끝!");
        gameOverObj.SetActive(true);
    }

    // Buy Tower Button Text 변경 메소드
    public void SetbuttonText(int value)
    {
        buyTowerText.text = "Buy Tower (" + value + "G)";
    }

}
