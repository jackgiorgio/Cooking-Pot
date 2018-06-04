using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public Item[] itemsInInventory;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void AddItem(Item item, int slot)
    {
        //Debug.Log("Add item to Crafter: " + item.name)
        itemsInInventory[slot-1] = item;

    }

    public void RemoveItem(int slot)
    {
        //Debug.Log("Remove from slot " + slot);
        itemsInInventory[slot-1] = null;

    }
}
