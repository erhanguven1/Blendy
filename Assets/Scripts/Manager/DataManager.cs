using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{ 

    public static bool Vibration
    {
        get => PlayerPrefs.GetInt("Vibration", 1) == 1;
        set => PlayerPrefs.SetInt("Vibration", value ? 1 : 0);

    }

    public static int DefaultCurrencyAmount;
    private static string CurrencyKey = "CurrencyKey";
    public static UnityAction OnCurrencyUpdate;
    public static int Currency
    {
        get => PlayerPrefs.GetInt(CurrencyKey, DefaultCurrencyAmount);
        set
        {
            PlayerPrefs.SetInt(CurrencyKey, value);
            OnCurrencyUpdate?.Invoke();
            
        }
    }


   
   


   // public int CurrentLevel;
    private static string LevelKey = "LevelKey";
    public static UnityAction OnLevelUpdate;
    public static int CurrentLevel
    {
        get => PlayerPrefs.GetInt(LevelKey, 0);
 
        set
        {
            PlayerPrefs.SetInt(LevelKey, value);
            OnLevelUpdate?.Invoke();
        }
    }

    private static string ZoneKey = "ZoneKey";
    public static int CurrentZone
    {
        get => PlayerPrefs.GetInt(ZoneKey, 0);
        set
        {
            PlayerPrefs.SetInt(ZoneKey, value);
 
        }
    }

    //   public UnityAction OnCharacterChange;
    //   private string CharacterKey = "CharacterKey";
    //   private bool isCharacterLoaded;
    //   private int characterId;
    //   public int CharacterId
    //   {
    //       get
    //       {
    //           if (!isCharacterLoaded)
    //           {
    //               CharacterId = PlayerPrefs.GetInt(CharacterKey, 0);
    //               isCharacterLoaded = true;
    //           }
    //           return characterId;
    //       }
    //
    //       set
    //       {
    //           characterId = value;
    //           OnCharacterChange?.Invoke();
    //           PlayerPrefs.SetInt(CharacterKey, characterId);
    //
    //       }
    //   }
    //
    //
    //   public GameObject GetSkin()
    //   {
    //
    //       return Characters[CharacterId];
    //   }


    private static readonly string KeyCountKey = "KeyCount";
    private static bool isKeyLoaded;
    private static int keyCount;
    public static int KeyCount
    {
        get
        {
            if (!isKeyLoaded)
            {
                KeyCount = PlayerPrefs.GetInt(KeyCountKey, 0);
                isKeyLoaded = true;
            }
            return keyCount;
        }

        set
        {
            keyCount = value;
            if (keyCount > 3)
                keyCount = 3;
            PlayerPrefs.SetInt(KeyCountKey, keyCount);
        }
    }


}
