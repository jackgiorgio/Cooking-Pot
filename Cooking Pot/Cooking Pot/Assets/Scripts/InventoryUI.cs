using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

    [SerializeField]
    InventorySlot[] slots;
    Inventory inventory;
    
    // Use this for initialization
	void Start () {
        slots = GetComponentsInChildren<InventorySlot>();
        SetUp();
        inventory = Inventory.instance;
        inventory.onItemChangeCallback += SetUp;
    }
    
    

    void SetUp()
    {
        for (int i = 0; i < Inventory.instance.itemsInInventory.Length; i++)
        {
            Item item = Inventory.instance.itemsInInventory[i];
            if (item != null & slots[i].itemObj==null)
            {
                if (item.itemTpye == Item.ItemType.food)
                {
                    slots[i].InstantiateFoodDisplay(item);
                }
                if (item.itemTpye == Item.ItemType.dish)
                {
                    slots[i].InstantiateDishDisplay(item);
                }
            }
        }
    }
	
}
