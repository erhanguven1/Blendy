using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    public GameObject top;
    public static FruitController Instance;
    public List<Fruit> fruits = new List<Fruit>();

    

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropFruit.Instance.DisableTouchs();
            top.GetComponent<Collider>().enabled = true;
            WaterController.Instance.ActivateTouchs();
            GamePlayManager.Instance.currentGameState = GameState.juicing;
        }
    }

    void ShakeBlender()
    {

    }
}
