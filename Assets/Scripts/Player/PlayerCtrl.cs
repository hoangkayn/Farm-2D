using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : BaseMono
{
    protected static PlayerCtrl instance;
    public static PlayerCtrl Instance => instance;
    [SerializeField] protected Animator animBody;
    [SerializeField] protected Animator animTool;
    [SerializeField] protected ObjMovement objMovement;
    public ObjMovement ObjMovement => objMovement;
    public Animator AnimBody => animBody;
    public Animator AnimTool => animTool;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnim();
        this.LoadMovement();
    }
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
    protected virtual void LoadAnim() {
        if (animBody != null) return;
        animBody = transform.Find("Model").Find("Body").GetComponent<Animator>();
        animTool = transform.Find("Model").Find("Tool").GetComponent<Animator>();
        
    }
    protected virtual void LoadMovement()
    {

        if (objMovement != null) return;
        objMovement = transform.GetComponentInChildren<ObjMovement>();
    }


}
