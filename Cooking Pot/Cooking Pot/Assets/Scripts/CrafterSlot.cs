using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CrafterSlot : MonoBehaviour, IDropHandler {

	public GameObject itemObj;

	public int slot;

	public void OnDrop(PointerEventData eventData)
	{
		Debug.Log("OnDrop");

		if (!itemObj & DragHandler.GetItemBeingDragged().isCookable)
		{
			itemObj = DragHandler.objBeingDragged;
			itemObj.transform.SetParent(transform);
			itemObj.transform.position = transform.position;
            itemObj.GetComponent<FoodDisplay>().EnableBackFrame();
            itemObj.GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
            FoodCrafter.instance.AddItem(DragHandler.GetFoodBeingDraged(), slot);
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




}
