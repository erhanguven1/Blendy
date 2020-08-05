using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class LevelManager: MonoBehaviour
{
    #region Singleton
    public static LevelManager Instance;
    private void Awake()
    {
        if (Instance)
        {
            Destroy(this);
            return;
        }
        Instance = this;


    }
    #endregion

    public List<LevelBase> Levels;

 
}
