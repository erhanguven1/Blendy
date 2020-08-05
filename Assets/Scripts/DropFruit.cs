using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;
using System;
using DG.Tweening;

public class DropFruit : MonoBehaviour
{
    public static DropFruit Instance;
    private void Awake()
    {
        Instance = this;
    }

    public Fruit fruit;

    public float timeDelta;

    // Start is called before the first frame update
    void Start()
    {
        TouchManager.Instance.onTouchBegan += TouchBegan;
        TouchManager.Instance.onTouchMoved += TouchMoved;
    }
    private void TouchBegan(TouchInput touch)
    {
        timeDelta = 0;
    }

    public void DisableTouchs()
    {
        TouchManager.Instance.onTouchBegan -= TouchBegan;
        TouchManager.Instance.onTouchMoved -= TouchMoved;
    }

    private void TouchMoved(TouchInput touch)
    {
        if (timeDelta == 0 || timeDelta > .2f)
        {
            timeDelta = 0;
            DropIt();
        }

        timeDelta += Time.deltaTime;
    }

    public void DropIt()
    {
        var f = Instantiate(fruit, transform.position+Vector3.right * UnityEngine.Random.Range(-3f, 3f) + Vector3.forward * UnityEngine.Random.Range(-2f, 2f), Quaternion.identity);
        f.GetComponent<Rigidbody>().AddForce(Vector3.down * 500);
        FruitController.Instance.fruits.Add(f);


    }
}