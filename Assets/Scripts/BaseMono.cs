using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMono : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponents();
    }
    protected virtual void LoadComponents()
    {

    }
    protected virtual void Awake()
    {
        this.LoadComponents();
    }
    protected virtual void Start()
    {

    }
    protected virtual void OnEnable()
    {
        
    }
    protected virtual void OnDisable()
    {
        
    }

}
