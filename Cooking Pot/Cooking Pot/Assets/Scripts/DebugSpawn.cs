using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugSpawn : MonoBehaviour {

    public Text itemText;
    public Text log;

    public void AddItem()
    {
        if (itemText.text == "All Recipes")
        {
            GetRecipeList();
            return;
        }
        if (itemText.text == "All Items")
        {
            GetItemList();
            return;
        }
        if (itemText.text == "All Foods")
        {
            GetFoodList();
            return;
        }
        if (itemText.text != "")
        {
            log.text = log.text += Inventory.instance.DebugSpawn(itemText.text) + "\n";
        }
    }

    void GetRecipeList()
    {
        log.text = "";
        for (int i = 0; i < Inventory.instance.dishpool.Length; i++)
        {
            log.text = log.text += Inventory.instance.dishpool[i].name + "\n";
        }
    }

    void GetItemList()
    {
        log.text = "";
        for (int i = 0; i < Inventory.instance.itempool.Length; i++)
        {
            log.text = log.text += Inventory.instance.itempool[i].name + "\n";
        }
    }

    void GetFoodList()
    {
        log.text = "";
        for (int i = 0; i < Inventory.instance.foodpool.Length; i++)
        {
            log.text = log.text += Inventory.instance.foodpool[i].name + "\n";
        }
    }





}
