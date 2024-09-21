using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateManager : BaseMono
{
    protected static StateManager instance;
    public static StateManager Instance => instance;
    protected  GameState currentState = GameState.Normal;
    public GameState CurrentStatee => currentState;
    protected override void Awake()
    {
        base.Awake();
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public virtual void SetState(GameState state)
    {
        currentState = state;
    }
       
   
}
