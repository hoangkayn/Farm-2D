using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UseItem : BaseMono
{
   protected virtual void Update()
    {
        this.Use();
    }
    protected virtual void Use()
    {
        if (StateManager.Instance.CurrentStatee != GameState.Normal) return;
        if (!InputManager.Instance.IsMouse0) return;
        if (EventSystem.current.IsPointerOverGameObject()) return;
       
        this.PerformAction();
        
    }
    private void PerformAction()
    {
        switch (ActionManager.Instance.currentActionType)
        {
            case ActionType.TillSoil:
                // Lấy vị trí chuột trên màn hình và chuyển sang vị trí thế giới
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                worldPosition.z = 0; // Đặt z = 0 để lấy vị trí trên mặt phẳng 2D

                ActionManager.Instance.TillSoli(worldPosition);
                break;

            case ActionType.WaterSoil:
                ActionManager.Instance.WaterSoli();
                break;

            case ActionType.PlantSeed:
                // Gieo hạt giống
                worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                worldPosition.z = 0; // Đặt z = 0 để lấy vị trí trên mặt phẳng 2D
                ActionManager.Instance.PlantSeed(worldPosition);
                break;

            case ActionType.BreakRock:
                ActionManager.Instance.BreakRock();
                break;
        }
    }
}
