using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{

    public GameObject itemObj;

    public int slot;

    private void Start()
    {
        if (itemObj)
        {
            AddItemToInventory();
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        bool stackable = false;
        Item itemBeingDragged = DragHandler.GetItemBeingDragged();
        Item itemBeingDropped = ScriptableObject.CreateInstance<Item>();
        if (itemObj)
        {
            stackable = itemObj.GetComponent<ItemDisplay>().item.isStackable;
            itemBeingDropped = itemObj.GetComponent<ItemDisplay>().item;
        }
        if (itemObj == null || (itemObj !=null & stackable==true & itemBeingDragged.name == itemBeingDropped.name))  
        {
            itemObj = DragHandler.objBeingDragged;
            itemObj.transform.SetParent(transform);
            itemObj.GetComponent<RectTransform>().sizeDelta = new Vector2(90, 90);
            itemObj.transform.position = transform.position;
            Inventory.instance.AddItem(DragHandler.GetItemBeingDragged(), slot);
        }
    }

    void Update()
    {
        if (itemObj != null)
        {
            if (itemObj.transform.parent != transform)
            {
                Inventory.instance.RemoveItem(slot);
                itemObj = null;
            }
        }
    }

    public void AddItemToInventory()
    {
        itemObj = transform.GetChild(0).gameObject;
        ItemDisplay display = itemObj.GetComponent<ItemDisplay>();
        Inventory.instance.AddItem(display.item, slot);
    }



}