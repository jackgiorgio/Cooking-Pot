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
            //假如物品是食物，则将其重置其腐烂程度
            if (itemObj)
            {
                if (itemObj.GetComponent<FoodDisplay>())
                {                    
                    itemObj.GetComponent<FoodDisplay>().AveragePerish(DragHandler.GetFoodDisplay());
                }


                //假如物品可堆叠，则将数量进行堆叠
                if (itemObj.GetComponent<ItemDisplay>().item.isStackable)
                {
                    itemObj.GetComponent<ItemDisplay>().Stack(DragHandler.GetItemDisplay().Amount);
                }
            }

            itemObj = DragHandler.objBeingDragged;
            itemObj.transform.SetParent(transform);
            itemObj.GetComponent<RectTransform>().sizeDelta = new Vector2(90, 90);
            itemObj.transform.position = transform.position;
            if (itemObj)
            {
                itemObj.GetComponent<FoodDisplay>().EnableBackFrame();
            }
            Inventory.instance.AddItem(DragHandler.GetItemBeingDragged(), slot);
            
            //假如有两个child在transform里
            if (transform.childCount > 1)
            {
                Destroy(itemObj);
                itemObj = transform.GetChild(0).gameObject;
            }
   
            
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