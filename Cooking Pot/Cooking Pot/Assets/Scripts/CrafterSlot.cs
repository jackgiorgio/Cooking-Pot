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

        //�����Ʒ��Ϊ�գ�������Ʒ�ǿɷŽ�����ģ���Ž�����
		if (!itemObj & DragHandler.GetItemBeingDragged().isCookable)
		{
            itemObj = DragHandler.objBeingDragged;
            //�����ק����Ʒ��ֹһ��������itembeingdragged��������������1��������һ���µ�prefab������(�������������ó̶�)��
            if (itemObj.GetComponent<ItemDisplay>().Amount > 1)
            {
                itemObj.GetComponent<FoodDisplay>().Amount -= 1;
                InstantiateFoodDisplay(DragHandler.GetItemBeingDragged());
                itemObj.GetComponent<ItemDisplay>().Amount = 1;
                itemObj.GetComponent<FoodDisplay>().freshStart = false;
                itemObj.GetComponent<FoodDisplay>().perishTime = DragHandler.GetFoodDisplay().perishTime;
                ResetTransform();
            }
            else
            {
                itemObj.transform.SetParent(transform);
                itemObj.transform.position = transform.position;
                ResetTransform();
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
    }

    void ResetTransform()
    {
        itemObj.GetComponent<FoodDisplay>().EnableBackFrame();
        itemObj.GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
        FoodCrafter.instance.AddItem(DragHandler.GetFoodBeingDraged(), slot);
    }




}
