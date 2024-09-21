    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementByInput : ObjMovement
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
    }
    protected virtual void LoadPlayerCtrl()
    {
        this.playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
    }
    protected override void GetDirection()
    {

        direction = InputManager.Instance.DirectionInput;

          if (IsMoving())
          {
              playerCtrl.AnimBody.SetFloat("MoveX", direction.x);
              playerCtrl.AnimBody.SetFloat("MoveY", direction.y);
            playerCtrl.AnimTool.SetFloat("MoveX", direction.x);
            playerCtrl.AnimTool.SetFloat("MoveY", direction.y);

           

        }
             playerCtrl.AnimBody.SetBool("IsMoving", isMoving);
        
      }
        
    
}
