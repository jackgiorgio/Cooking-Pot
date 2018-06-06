using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CrafterSlot : MonoBehaviour, IDropHandler {

	public GameObject itemObj;
    public GameObject foodPrefab;

	public int slot;

	public void OnDrop(PointerEventData eventData)
	{
		Debug.Log("OnDrop");

        //如果物品槽为空，而且物品是可放进锅里的，则放进锅里
		if (!itemObj & DragHandler.GetItemBeingDragged().isCookable)
		{
            itemObj = DragHandler.objBeingDragged;
            //如果拖拽的物品不止一个，则保留itembeingdragged，并将其数量减1，并产生一个新的prefab在那里(更新数量及腐烂程度)；
            if (itemObj.GetComponent<ItemDisplay>().Amount > 1)
            {
                itemObj.GetComponent<FoodDisplay>().Amount -= 1;
                InstantiateFoodDisplay(DragHandler.GetItemBeingDragged());
                itemObj.GetComponent<ItemDisplay>().Amount = 1;
                itemObj.GetComponent<FoodDisplay>().freshStart = false;
                itemObj.GetComponent<FoodDisplay>().perishTime = DragHandler.GetFoodDisplay().perishTime;
                ResetTransform();
                FoodCrafter.instance.AddItem(DragHandler.GetFoodBeingDraged(), slot);
            }
            else
            {
                itemObj.transform.SetParent(transform);
                itemObj.transform.position = transform.position;
                ResetTransform();
                FoodCrafter.instance.AddItem(DragHandler.GetFoodBeingDraged(), slot);
            }
            
        }
	}

	void Update ()
	{
		if (itemObj != null)
		{
			if (itemObj.transform.parent != transform)
			{
                FoodCrafter.instance.RemoveItem(slot);
				itemObj = null;
			}
		}
	}

    public void RemoveItem(int _slot)
    {
        FoodCrafter.instance.RemoveItem(_slot);
        itemObj =null;
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
          }
    }

    public void InstantiateFoodDisplay(Item _item)
    {
        itemObj = Instantiate(foodPrefab, transform);
        itemObj.transform.SetParent(transform);
        itemObj.GetComponent<FoodDisplay>().food = Inventory.instance.FindFood(_item.name);
        itemObj.GetComponent<ItemDisplay>().item = Inventory.instance.FindItem(_item.name);
    }

    public void ResetTransform()
    {
        itemObj.GetComponent<FoodDisplay>().EnableBackFrame();
        itemObj.GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
    }

    public void AddToFoodCrafter()
    {
        itemObj = transform.GetChild(0).gameObject;
        FoodDisplay display = itemObj.GetComponent<FoodDisplay>();
        FoodCrafter.instance.AddItem(display.food, slot);
    }




}
