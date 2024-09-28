using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : BaseMono
{
    [SerializeField] protected float tickFrequency = 0.2f;
    private static int currentTick = 0;
    public static int CurrentTick => currentTick;
    private float lastTickTime = 0;
    [SerializeField] protected static float currentGameTime;
    public static float CurrentGameTime => currentGameTime;
    public static Action OnTick;
    protected override void Awake()
    {
        base.Awake();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }
    protected virtual void Update()
    {
        this.Tick();
    }
    protected virtual void Tick()
    {
        currentGameTime += Time.deltaTime;
        if(currentGameTime >= lastTickTime + tickFrequency)
        {
            lastTickTime = currentGameTime;
            OnTick.Invoke();
            currentTick++;
        }
    }
}
