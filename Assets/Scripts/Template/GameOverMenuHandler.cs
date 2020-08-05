using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Tools.Extentions;

public enum GameOverStatu
{
    Success,
    Fail
}

public class GameOverMenuHandler : MonoBehaviour
{
    public GameObject SuccessMenu, FailMenu,Gameover;
    [SerializeField]
    private TextMeshProUGUI currencyText;
    public Button continueButton,retrybutton;

    public void Init(GameOverStatu gameOverStatu)
    {
        if(gameOverStatu == GameOverStatu.Success)
        {
            SuccessMenu.SetActive(true);
            FailMenu.SetActive(false);
            continueButton.interactable = false;
            SetCurrency();
            DataManager.OnCurrencyUpdate += SetCurrency;
            GainCurrency();


        }
        else if(gameOverStatu == GameOverStatu.Fail)
        {
            FailMenu.SetActive(true);
            SuccessMenu.SetActive(false);
        }
    }

    private void SetCurrency()
    {
        currencyText.text = DataManager.Currency.ToString();
    }

    public void OnContinueTap()
    {

        // DataManager.Instance.CurrentLevel++;
        DataManager.CurrentZone++;

        SceneManager.LoadScene("GameScene");

        

    }

    public void OnRetryTap()
    {

        SceneManager.LoadScene("GameScene"); 
    }

   

  private void GainCurrency()
    {
        var gainCoinValue = 50;
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", DataManager.Currency,
            "to", gainCoinValue + DataManager.Currency,
            "time", .5f,
            "easetype", iTween.EaseType.linear,
            "onupdate", "CurrencyUpdate",
            "oncomplete", "ActiviteContinueButton",
            "oncompletetarget", gameObject
        ));
    }

    void CurrencyUpdate(float value)
    {
        DataManager.Currency = Mathf.RoundToInt(value);


    }

    private void ActiviteContinueButton()
    {
        continueButton.interactable = true;
    }

    
   


   

}


   
  
    

