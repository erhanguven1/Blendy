using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using Tools.Extentions;
public class StartMenuHandler : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI currencyText;
    [SerializeField]
    private Image vibrationButton;
    [SerializeField]
    private Sprite hapticOn, hapticOff;
    public GameObject Settings, StartButton, MarketButton, MarketMenu;



    public GameMenuHandler GameMenuHandler;
    public ChestMarket ChestMarket;


    void Start()
    {



        if (DataManager.Vibration)
        {
            vibrationButton.sprite = hapticOn;
        }
        else
            vibrationButton.sprite = hapticOff;

        SetCurrency();
        DataManager.OnCurrencyUpdate += SetCurrency;



    }

    private void OnEnable()
    {
        if (DataManager.KeyCount == 3)
        {
            ChestMarket.gameObject.SetActive(true);
            ChestMarket.SetUI();
            gameObject.SetActive(false);
        }



    }



    public void OnStartButtonTap()
    {

        GamePlayManager.Instance.OnGameStart();
        GameMenuHandler.gameObject.SetActive(true);
        gameObject.SetActive(false);

    }


    private void SetCurrency()
    {
        currencyText.text = DataManager.Currency.ToString();
    }

    public void OnSettingsTap()
    {
        if (vibrationButton.gameObject.activeSelf == false)
        {
            vibrationButton.gameObject.SetActive(true);

        }
        else
        {
            vibrationButton.gameObject.SetActive(false);
        }

    }

    public void OnVibrationButtonTap()
    {
        if (DataManager.Vibration)
        {
            DataManager.Vibration = false;
            vibrationButton.sprite = hapticOff;
        }
        else
        {
            DataManager.Vibration = true;
            vibrationButton.sprite = hapticOn;
        }
    }

    public void OnCustomizeTap()
    {
        Settings.SetActive(false);
        MarketButton.SetActive(false);
        StartButton.SetActive(false);
        MarketMenu.SetActive(true);

    }


    public void OnCustomizeCloseTap()
    {
        MarketMenu.SetActive(false);
        Settings.SetActive(true);
        MarketButton.SetActive(true);
        StartButton.SetActive(true);



    }

}
