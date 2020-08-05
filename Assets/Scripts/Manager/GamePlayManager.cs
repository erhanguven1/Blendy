using System.Collections;
using System.Collections.Generic;
//using GameAnalyticsSDK;
using UnityEngine;

public enum GameState { addingFruit, juicing}

public class GamePlayManager : MonoBehaviour
{
    public GameState currentGameState;

    public static GamePlayManager Instance;

    public GameMenuHandler GameMenuHandler;
    public GameOverMenuHandler GameOverMenuHandler;

    public bool IsGameStarted, IsGameOver;
    public int CurrentZone;
  

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

    }

    public void OnGameStart()
    {
    
        IsGameStarted = true;
      //  GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, string.Format("Level {0}", DataManager.Instance.CurrentLevel));

      

    }

    public void OnLevelComplete()
    {

        IsGameOver = true;
        GameMenuHandler.gameObject.SetActive(false);
        GameOverMenuHandler.gameObject.SetActive(true);
        GameOverMenuHandler.Init(GameOverStatu.Success);
      //  GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, string.Format("Level {0}", DataManager.Instance.CurrentLevel));


    }

    public void OnDead()
    {

        IsGameOver = true;
        GameMenuHandler.OnDead();
        GameMenuHandler.gameObject.SetActive(false);
        GameOverMenuHandler.gameObject.SetActive(true);
        GameOverMenuHandler.Init(GameOverStatu.Fail);
       // GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, string.Format("Level {0}", DataManager.Instance.CurrentLevel));

    }

  

    public void KeyUIFlow()
    {
        GameMenuHandler.KeyUIFlow();
    }

   
    

}
