using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObject/Item")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public string descriptionOfUse;
    public ItemType itemType;  
    public Sprite itemIcon;    
    public ActionType actionType;
   
}
