using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiscoveryUI : MonoBehaviour {

    public Text resultText;
    private bool firstTime = true;
    Discovery discovery;
    DiscoverySlot[] slots;

    // Use this for initialization
    void Start () {
        discovery = Discovery.instance;
        slots = GetComponentsInChildren<DiscoverySlot>();
        discovery.onDiscoveryChangeCallBack += SetUp;
        SetUp();
        firstTime = false;
    }


    void SetUp()
    {
        for (int i = 0; i < discovery.recipeFound.Length; i++)
        {
            Dish dish = discovery.recipeFound[i];
            if (dish != null)
            {
                slots[i].Add(dish);
                if (!firstTime)
                {
                    discovery.EnableNewRecipePanel(dish);
                }
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
        UpdateResultText();
    }

    void UpdateResultText()
    {
        resultText.text = "Found:" + discovery.CountDiscoveredRecipe().ToString() + "/" + (discovery.recipes.Length).ToString();
    }
}
