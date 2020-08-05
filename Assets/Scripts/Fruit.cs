using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        JumpFruit();
    }
    // Update is called once per frame
    public void JumpFruit()
    {
        if (GamePlayManager.Instance.currentGameState == GameState.juicing && WaterController.Instance.goingUp)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 25 * Random.Range(-20, 20));
        }   
    }
}
