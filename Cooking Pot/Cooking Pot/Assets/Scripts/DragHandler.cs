using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public static GameObject objBeingDragged;
	public static Item GetItemBeingDragged ()
	{
            return objBeingDragged.GetComponent<ItemDisplay>().item;
	}

    public static Food GetFoodBeingDraged()
    {
        return objBeingDragged.GetComponent<FoodDisplay>().food;
    }


    Vector3 startPosition;
	Transform startParent;

	Transform itemDraggerParent;
	CanvasGroup canvasGroup;
	Animator animator;

	void Start ()
	{
		canvasGroup = GetComponent<CanvasGroup>();
		itemDraggerParent = GameObject.FindGameObjectWithTag("ItemDraggerParent").transform;
		animator = GetComponent<Animator>();
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		objBeingDragged = gameObject;
		startPosition = transform.position;
		startParent = transform.parent;

		//animator.SetTrigger("Pickup");

		transform.SetParent(itemDraggerParent);

		canvasGroup.blocksRaycasts = false;

		AudioManager.instance.Play("Clock");
	}

	public void OnDrag(PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		objBeingDragged = null;
		canvasGroup.blocksRaycasts = true;

		if (transform.parent == itemDraggerParent)
		{
			transform.position = startPosition;
			transform.SetParent(startParent);

            //recreate the connections just like in the ondrop function

            InventorySlot slot = gameObject.GetComponentInParent<InventorySlot>();
            if (slot)
            {
                slot.AddItemToInventory();
            }

		}

		AudioManager.instance.Play("Unclick");
	}
}
