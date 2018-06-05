using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public static GameObject objBeingDragged;

    public static ItemDisplay GetItemDisplay()
    {
        return objBeingDragged.GetComponent<ItemDisplay>();
    }

    public static FoodDisplay GetFoodDisplay()
    {
        return objBeingDragged.GetComponent<FoodDisplay>();
    }

    public static Item GetItemBeingDragged ()
	{
            return objBeingDragged.GetComponent<ItemDisplay>().item;
	}

    public static Food GetFoodBeingDraged()
    {
        return objBeingDragged.GetComponent<FoodDisplay>().food;
    }


    Vector3 startPosition;
    [HideInInspector]
    public Vector3 StartPosition
    {
        get
        {
            return startPosition;
        }
        set
        {
            startPosition = value;
        }
    }
	Transform startParent;
    [HideInInspector]
    public Transform StartParent
    {
        get
        {
            return startParent;
        }
        set
        {
            startParent = value;
        }
    }

	Transform itemDraggerParent;
    public Transform ItemDraggerParent
    {
        get
        {
            return itemDraggerParent;
        }
    }
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
        if (objBeingDragged.GetComponent<FoodDisplay>())
        {
            objBeingDragged.GetComponent<FoodDisplay>().DisableBackFrame();
        }
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
        BacktoPrviousPosition();

		AudioManager.instance.Play("Unclick");
	}

    public void BacktoPrviousPosition()
    {
        if (transform.parent == itemDraggerParent)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);

            //recreate the connections just like in the ondrop function

            InventorySlot slot = gameObject.GetComponentInParent<InventorySlot>();
            if (slot)
            {
                slot.AddItemToInventory();
                if (slot.GetComponentInChildren<FoodDisplay>())
                {
                    slot.GetComponentInChildren<FoodDisplay>().EnableBackFrame();
                }
            }


        }
    }
}
