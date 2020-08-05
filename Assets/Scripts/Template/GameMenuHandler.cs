using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class GameMenuHandler : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI currentLevel, currencyText, nextLevel;
    public Image[] zoneImages;
    public Image feverFill;
    public GameObject feverText;

    public GameObject coinPrefab;
    public Transform coinEndPos;

    public List<GameObject> yellowKeys, whiteKeys;
    public GameObject KeyImagePrefab;
    private Vector3 keyEndPos;

    public Camera UICam;


    void Start()
    {
        SetUI();
        //  TouchManager.Instance.onTouchBegan += TutorialClose;
        SetCurrency();
        DataManager.OnCurrencyUpdate += SetCurrency;
    }

    public void SetUI()
    {
        currentLevel.text = (DataManager.CurrentLevel).ToString();
        nextLevel.text = (DataManager.CurrentLevel + 1).ToString();


        //KAÇ ZONE VARSA ONA GÖRE
        for (int i = 0; i < DataManager.CurrentZone; i++)
        {
            zoneImages[i].color = Color.green;

        }


        for (int i = 0; i < 3; i++)
        {
            yellowKeys[i].SetActive(false);
            whiteKeys[i].SetActive(true);
        }

        var keyCount = DataManager.KeyCount;
        for (int i = 0; i < keyCount; i++)
        {

            yellowKeys[i].SetActive(true);
            whiteKeys[i].SetActive(false);
        }


    }

    private void SetCurrency()
    {
        currencyText.text = DataManager.Currency.ToString();
    }


    public void SetFeverFill(float _percantage)
    {
        float percantage = _percantage / 100;
        feverFill.fillAmount = percantage;
        if (percantage >= 1)
        {
            feverText.gameObject.SetActive(true);
        }
    }


    public void CoinFlow()
    {
        var coin = Instantiate(coinPrefab, transform);
        coin.GetComponent<RectTransform>().localPosition = Vector3.zero;


        StartCoroutine(CoinFlow(coin));

    }
    IEnumerator CoinFlow(GameObject coin)
    {
        float time = 0f;
        float timer = 1f;
        Vector3 firstCoinPos = coin.transform.position;


        while (time < timer)
        {
            coin.transform.position = Vector3.Lerp(firstCoinPos, coinEndPos.position, time / timer);
            time += Time.deltaTime;
            yield return null;
        }

        coin.transform.position = coinEndPos.position;
        DataManager.Currency += 10;
        iOSHapticFeedback.Instance.Trigger(iOSHapticFeedback.iOSFeedbackType.ImpactLight);

        yield return new WaitForSeconds(1f);

        Destroy(coin);

    }
   

    public void KeyUIFlow()
    {
        var key = Instantiate(KeyImagePrefab, transform);
        key.GetComponent<RectTransform>().localPosition = Vector3.zero;


        StartCoroutine(KeyFlow(key));


    }

    private bool IsKeyTaken = false;
    IEnumerator KeyFlow(GameObject key)
    {
        float time = 0f;
        float timer = 1f;
        Vector3 firstKeyPos = key.transform.position;
        keyEndPos = yellowKeys[DataManager.KeyCount].transform.position;

        while (time < timer)
        {
            key.transform.position = Vector3.Lerp(firstKeyPos, keyEndPos, time / timer);
            time += Time.deltaTime;
            yield return null;
        }


        DataManager.KeyCount++;
        IsKeyTaken = true;

        iOSHapticFeedback.Instance.Trigger(iOSHapticFeedback.iOSFeedbackType.ImpactMedium);

        Destroy(key);

        for (int i = 0; i < 3; i++)
        {
            yellowKeys[i].SetActive(false);
            whiteKeys[i].SetActive(true);
        }

        var keyCount = DataManager.KeyCount;
        for (int i = 0; i < keyCount; i++)
        {

            yellowKeys[i].SetActive(true);
            whiteKeys[i].SetActive(false);
        }

    }

    public void OnDead()
    {
        if (IsKeyTaken)
        {
            DataManager.KeyCount--;
        }
    }



}
