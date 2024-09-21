using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BtnSelectItem : BaseBtn
{
    [SerializeField] protected Image image;
   
    [SerializeField] protected TextMeshProUGUI text;
    [SerializeField] protected ItemInventory itemInventory;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadImage();
        this.LoadText();
    }
    protected virtual void LoadImage()
    {
        if (image != null) return;
        image = transform.Find("ImgItem").GetComponentInChildren<Image>();
    }
    protected virtual void LoadText()
    {
        if (text != null) return;
        text = transform.GetComponentInChildren<TextMeshProUGUI>();
    }
    protected override void OnClick()
    {
        ActionType actionType = itemInventory.itemSO.actionType;
        ActionManager.Instance.currentActionType = actionType;
    }
    public virtual void SetImage(Sprite sprite)
    {
        this.image.sprite = sprite;
    }
    public virtual void SetText(int count)
    {
        if (count <= 1) return;
        this.text.text = count.ToString();
    }
    public virtual void SetItemInv(ItemInventory item)
    {
        this.itemInventory = item;
    }

}
