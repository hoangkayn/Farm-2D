using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHotKey : BaseMono
{
    [SerializeField] protected List<BtnSelectItem> btnSelectItems;
    public List<BtnSelectItem> BtnSelectItems => btnSelectItems;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtnSelectItems();
    }
    protected virtual void LoadBtnSelectItems()
    {
        if (btnSelectItems.Count > 0) return;
        BtnSelectItem[] btnSelects = transform.GetComponentsInChildren<BtnSelectItem>();
        foreach(BtnSelectItem btnSelect in btnSelects)
        {
            this.btnSelectItems.Add(btnSelect);
        }
    }
    protected override void Start()
    {
        base.Start();
     
        
    }
    protected virtual void FixedUpdate()
    {
        this.ShowItem();
    }
    protected virtual void ShowItem()
    {
        List<ItemInventory> items = Inventory.Instance.Items;

        // Duyệt qua các button
        for (int i = 0; i < btnSelectItems.Count; i++)
        {
            BtnSelectItem btnSelectItem = this.btnSelectItems[i];

            // Kiểm tra nếu item tồn tại tại chỉ mục i
            if (i >= items.Count) break;
            
                ItemInventory item = items[i];
                btnSelectItem.SetImage(item.itemSO.itemIcon);
                btnSelectItem.SetText(item.itemCount);
                btnSelectItem.SetItemInv(item);
            
        }
    }


}

