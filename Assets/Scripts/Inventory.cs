using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Inventory : BaseMono
{
    protected static Inventory instance;
    public static Inventory Instance => instance;
    [SerializeField] protected int maxSlot = 8;
    [SerializeField] protected List<ItemInventory> items = new List<ItemInventory>();
    public List<ItemInventory> Items => items;

    protected override void Awake()
    {
        base.Awake();
        if(instance != this && instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public virtual void SetItems(List<ItemInventory> items)
    {
        this.items = items;
    }
    protected override void Start()
    {
        base.Start();
        this.AddItem("Rìu", 1);
        this.AddItem("Cuốc", 1);
        this.AddItem("Bình Nước", 1);
        this.AddItem("Cuốc Chim", 1);
        
    }

    public virtual bool AddItem(string itemName, int addCount)
    {

        if (!this.ContainsItem(itemName))
        {
            if (this.IsInventoryFull()) return false;
            ItemSO itemSO = this.GetItemSO(itemName);
            ItemInventory item = CreatEmptyItem(itemSO);
            item.itemCount = addCount;
            this.items.Add(item);
           
        }
        else
        {
            this.FindItemInvByItemName(itemName).itemCount += addCount;
        }
        return true;
    }
    protected virtual ItemInventory FindItemInvByItemName(string itemName)
    {
        foreach(ItemInventory item in items)
        {
            if (item.itemSO.itemName == itemName)
                return item;
        }
        return null;
    }

    protected virtual bool IsInventoryFull()
    {
        if (this.items.Count >= this.maxSlot) return true;
        return false;
    }
    protected virtual bool ContainsItem(string itemName) {
        foreach (ItemInventory itemInventory in items)
        {
            if (itemInventory.itemSO.itemName == itemName)
                return true;
        }
        return false;
    }



    protected virtual ItemSO GetItemSO(string itemName)
    {
        var profiles = Resources.LoadAll("SO/Item", typeof(ItemSO));
        foreach (ItemSO profile in profiles)
        {
            if (profile.itemName != itemName) continue;
            return profile;
        }
        return null;
    }
    protected virtual ItemInventory CreatEmptyItem(ItemSO itemSO)
    {
        ItemInventory itemInventory = new ItemInventory();

        itemInventory.itemSO = itemSO;
        return itemInventory;
    }

    public virtual void DeductItem(string itemName, int itemCount)
    {
        ItemInventory itemInventory;
        int deduct;
        for (int i = this.items.Count - 1; i >= 0; i--)
        {
            itemInventory = items[i];

            if (itemInventory.itemSO.itemName != itemName) continue;

            if (itemCount > itemInventory.itemCount)
            {
                deduct = itemInventory.itemCount;
            }
            else
            {
                deduct = itemCount;
            }
            itemInventory.itemCount -= deduct;
        }
        this.ClearEmptySlot();
    }

    protected virtual void ClearEmptySlot()
    {
        ItemInventory itemInventory;
        for (int i = 0; i < this.items.Count; i++)
        {
            itemInventory = this.items[i];
            if (itemInventory.itemCount == 0) this.items.RemoveAt(i);
        }
    }
}
