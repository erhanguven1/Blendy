using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;
using System;

public class WaterController : MonoBehaviour
{
    public static WaterController Instance;
    public bool goingUp;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject mask;

    private void Start()
    {

    }

    public void ActivateTouchs()
    {
        TouchManager.Instance.onTouchBegan += TouchBegan;
        TouchManager.Instance.onTouchMoved += TouchMoved;
        TouchManager.Instance.onTouchEnded += TouchEnded;
    }

    private void TouchBegan(TouchInput touch)
    {
        AddWater();
    }

    private void TouchMoved(TouchInput touch)
    {
        MoveWater();
    }

    private void TouchEnded(TouchInput touch)
    {
        EndWater();
    }

    public void AddWater()
    {
        DOTween.To(() => WaveGenerator.Instance.speed, x => WaveGenerator.Instance.speed = x, 1, .5f);
    }

    public void MoveWater()
    {
        goingUp = true;
        transform.position += Vector3.up * Time.deltaTime / 2;
    }

    public void EndWater()
    {

        goingUp = false;
        DOTween.To(() => WaveGenerator.Instance.speed, x => WaveGenerator.Instance.speed = x, 0, .5f);
    }
}
