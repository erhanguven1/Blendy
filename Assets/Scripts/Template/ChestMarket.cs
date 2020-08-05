using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Tools.Extentions;

public class ChestMarket : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI currencyText;

    public StartMenuHandler StartMenuHandler;

    public List<GameObject> yellowKeys, whiteKeys;

    public List<Button> ChestButtons;
    public Sprite OpenParentSprite, OpenChestSprite,CloseParentSprite,CloseChestSprite;
    public GameObject CloseButton, CoinPrefab;
    public Transform coinTransformFinal;
    private Transform coinTransformStart;
    int gainedCurrency;
    public GameObject GainCurrencyPrefab;
    private List<GameObject> gainCurrencyTexts = new List<GameObject>();
    


    private List<int> gainedCurrencies = new List<int>() { 25, 50, 75, 100, 150, 200, 250 };





    // Start is called before the first frame update
    public void SetUI()
    {

        SetCurrency();
        DataManager.OnCurrencyUpdate += SetCurrency;

        //DataManager.Instance.KeyCount = 3;

        foreach (var button in ChestButtons)
        {
            button.GetComponent<Image>().sprite = CloseParentSprite;
            button.transform.GetChild(0).gameObject.SetActive(true);
            button.transform.GetChild(0).GetComponent<Animator>().enabled = true;
            button.transform.GetChild(0).GetComponent<Image>().sprite = CloseChestSprite;
        }

        if (gainCurrencyTexts.Count != 0)
        {
            for (int i = gainCurrencyTexts.Count-1; i >= 0; i--)
            {
                Destroy(gainCurrencyTexts[i]);
            }

            gainCurrencyTexts.Clear();
        }

        var keyCount = DataManager.KeyCount;

        for (int i = 0; i < keyCount; i++)
        {

            yellowKeys[i].SetActive(true);
            whiteKeys[i].SetActive(false);
        }

        if (keyCount != 3)
        {
            foreach (var button in ChestButtons)
            {
                button.interactable = false;
                button.transform.GetChild(0).GetComponent<Animator>().enabled = false;
            }
        }
        else
        {
            CloseButton.SetActive(false);
        }


    }

    private void SetCurrency()
    {
        currencyText.text = DataManager.Currency.ToString();
    }

    private void RefreshUI() //buttonlar kapanmasın diye bunu koydum
    {
        currencyText.text = DataManager.Currency.ToString();

        var keyCount = DataManager.KeyCount;

        for (int i = 0; i < 3; i++)
        {
            yellowKeys[i].SetActive(false);
            whiteKeys[i].SetActive(true);
        }

        for (int i = 0; i < keyCount; i++)
        {

            yellowKeys[i].SetActive(true);

            whiteKeys[i].SetActive(false);

        }

        if (keyCount != 0)
        {
            CloseButton.SetActive(false);
        }
        else
        {
            foreach (var button in ChestButtons)
            {
                button.interactable = false;
                button.transform.GetChild(0).GetComponent<Animator>().enabled = false;
                CloseButton.SetActive(true);
            }

        }



    }





    public void OnCloseTap()
    {
        StartMenuHandler.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnChestTap(int chestNo)
    {
        var button = ChestButtons[chestNo];
        button.GetComponent<Image>().sprite = OpenParentSprite;
        button.transform.GetChild(0).GetComponent<Animator>().enabled = false;
        button.transform.GetChild(0).GetComponent<Image>().sprite = OpenChestSprite;
        DataManager.KeyCount--;


        RewardRoutine(button.gameObject, button.transform.position);


        RefreshUI();


    }

    private void RewardRoutine(GameObject button, Vector3 chestPosition)
    {
        gainedCurrency = gainedCurrencies.RandomItem();


        button.transform.GetChild(0).gameObject.SetActive(false);


        var gainCurrencyGroup = Instantiate(GainCurrencyPrefab, transform);
        gainCurrencyGroup.transform.localScale = Vector3.zero;
        gainCurrencyGroup.transform.position = chestPosition;
        coinTransformStart = gainCurrencyGroup.transform.GetChild(1).transform;
        var gainCurrencyText = gainCurrencyGroup.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        gainCurrencyText.text = string.Format("+{0}", gainedCurrency);
        gainCurrencyTexts.Add(gainCurrencyGroup);


        iTween.ScaleTo(gainCurrencyGroup, iTween.Hash(
     "name", "GainCurrency",
     "scale", Vector3.one,
      "time", 1f,
     "easetype", iTween.EaseType.easeOutBack,
      "oncomplete", "CurrencyFlow",
     "oncompletetarget", gameObject


  ));

    }


    private void CurrencyFlow()
    {
        StartCoroutine(FlowRoutine());
    }

    private List<GameObject> coins = new List<GameObject>();
    IEnumerator FlowRoutine()
    {

        DataManager.Currency += gainedCurrency;
        var coinCount = 5;


        var delayTime = 0f;
        var delay = .1f;
        for (int i = 0; i < coinCount; i++)
        {
            var time = 2f;
            var coin = Instantiate(CoinPrefab, coinTransformStart);
            // coin.transform.position = coinTransformStart.position;
            coin.transform.localPosition = Vector3.zero;
            coins.Add(coin);




            iTween.MoveTo(coin, iTween.Hash(
                "position", coinTransformFinal.position,
                "time", 1f,
                "delay", delayTime,
                "easetype", iTween.EaseType.easeOutSine
                ));





            //   delayTime += delay;

            yield return new WaitForSeconds(0.075f);

            iOSHapticFeedback.Instance.Trigger(iOSHapticFeedback.iOSFeedbackType.ImpactLight); //bak


        }


        for (int i = coins.Count - 1; i >= 0; i--)
        {
            Destroy(coins[i]);
        }

        coins.Clear();


     



    }

}
