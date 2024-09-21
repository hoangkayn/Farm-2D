using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : BaseMono
{
    protected static GameManager instance;
    public static GameManager Instance => instance;
    public bool isNewGame;
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
            DontDestroyOnLoad(gameObject);
        }
    }

}
