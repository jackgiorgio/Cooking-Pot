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

		if (!itemObj)
		{
			itemObj = DragHandler.objBeingDragged;
			itemObj.transform.SetParent(transform);
			itemObj.transform.position = transform.position;

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

}
