using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;  

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }
    #endregion


 
 

   

}
