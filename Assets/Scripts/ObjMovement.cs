using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjMovement : BaseMono
{
    [SerializeField] protected float speed = 0.03f;
    [SerializeField] protected Vector2 direction;
    public Vector2 Direction => direction;
    [SerializeField] protected bool isMoving = false;
    protected abstract void GetDirection();
    protected virtual void Update()
    {
        this.GetDirection();
    }
    protected virtual void FixedUpdate()
    {

        this.Moving();
    }
    protected virtual void Moving()
    {
        if (direction == Vector2.zero) return;
        transform.parent.Translate(speed * direction);
    }
    protected virtual bool IsMoving()
    {
        return isMoving = direction != Vector2.zero;
    }
}
