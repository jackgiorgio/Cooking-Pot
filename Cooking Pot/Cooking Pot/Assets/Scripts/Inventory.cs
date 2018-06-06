using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        instance = this;
        itempool = Resources.LoadAll<Item>("Items");
        foodpool = Resources.LoadAll<Food>("Items");
        dishpool = Resources.LoadAll<Dish>("Items");
    }

    #endregion

    public Item[] itemsInInventory;
    public int[] itemsAmount;
    public float[] itemsPerish;
    [HideInInspector]
    public Item[] itempool;
    [HideInInspector]
    public Food[] foodpool;
    [HideInInspector]
    public Dish[] dishpool;


    public delegate void OnItemChanged();
    public OnItemChanged onItemChangeCallback;


    public bool AddItem(Item item, int slot)
    {

        //Debug.Log("Add item to Crafter: " + item.name)
        itemsInInventory[slot-1] = item;
        if (onItemChangeCallback != null)
        {
            onItemChangeCallback.Invoke();
        }
        return true;
    }


    public void RemoveItem(int slot)
    {
        //Debug.Log("Remove from slot " + slot);
        itemsInInventory[slot-1] = null;
        if (onItemChangeCallback != null)
            onItemChangeCallback.Invoke();
    }

    public void AddItem(string name)
    {
        int emptySlot = GetEmptySlot();
        if (emptySlot < itemsInInventory.Length & FindItem(name)!=null)
        {
            AddItem(FindItem(name), emptySlot+1);
        }
    }

    public Item FindItem(string _name)
    {
        foreach (Item item in itempool)
        {
            if (item.name == _name)
            {
                Debug.Log("found " + item.name);
                return item;
            }
        }
        Debug.LogError("can't find " + name + "!");
        return null;
    }

    public Food FindFood(string _name)
    {
        foreach (Food food in foodpool)
        {
            if (food.name == _name)
            {
                Debug.Log("found " + food.name);
                return food;
            }
        }
        Debug.LogError("can't find " + name + "!");
        return null;
    }

    public Dish FindDish(string _name)
    {
        Debug.Log(_name);
        foreach (Dish dish in dishpool)
        {
            if (dish.name == _name)
            {
                Debug.Log("found " + dish.name);
                return dish;
            }
        }
        Debug.LogError("can't find " + name + "!");
        return null;
    }



    int GetEmptySlot()
    {
        for (int i = 0; i < itemsInInventory.Length; i++)
        {
            if (itemsInInventory[i] == null)
            {
                return i;
            }
        }
        Debug.LogError("can't find an empty slot!");
        return itemsInInventory.Length;
    }

    public string DebugSpawn(string name)
    {
        int emptySlot = GetEmptySlot();
        
        if (emptySlot < itemsInInventory.Length & FindItem(name) != null)
        {
            AddItem(FindItem(name), emptySlot + 1);
            string success = name + " added successfully";
            return success;
        }
        if (emptySlot >= itemsInInventory.Length)
        {
            return "Not enough space!";
        }
        return "Can't find "+ name +"!";

    }
}
