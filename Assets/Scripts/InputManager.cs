using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : BaseMono
{
    protected static InputManager instance;
    public static InputManager Instance => instance;
    [SerializeField] protected Vector2 directionInput;
    public Vector2 DirectionInput => directionInput;
    [SerializeField] protected bool isMouse0;
    public bool IsMouse0 => isMouse0;
   
    protected override void Awake()
    {
        base.Awake();
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    protected virtual void Update()
    {
        this.GetDirectionInput();
        this.GetMouseDown();
    }
  
    protected virtual void GetDirectionInput()
    {
        this.directionInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    protected virtual void GetMouseDown()
    {
        this.isMouse0 = Input.GetKeyDown(KeyCode.Mouse0);
    }


}
