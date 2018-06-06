using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discovery : MonoBehaviour {

    #region Singleton

    public static Discovery instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion


    public delegate void OnDiscoveryChange();
    public OnDiscoveryChange onDiscoveryChangeCallBack;
    public GameObject NewRecipePanel;
    public GameObject FoundRecipePanel;
    public DiscoveryDisplay discoveryDisplay;


    public Dish[] recipeFound;
    public Dish[] recipes;

    // Use this for initialization
    void Start () {
        recipes = Resources.LoadAll<Dish>("Items");
        SetUpDiscovery();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DiscoverDish(Dish _dish)
    {
        if (!IsDishDiscovered(_dish))
        {
            PlayerPrefs.SetInt(_dish.name, 1);
        }
        SetUpDiscovery();
    }



    void SetUpDiscovery()
    {

        foreach (Dish d in recipes)
        {
             if (!PlayerPrefs.HasKey(d.name))
             {
                 PlayerPrefs.SetInt(d.name, 0);
             }
         }
         foreach (Dish d in recipes)
         {
            if (PlayerPrefs.GetInt(d.name) == 1 & !IsDishDiscovered(d))
            {
                 Addrecipe(d);
             }
         }
    }


    public void Addrecipe(Dish dish)
    {
        recipeFound[EmptySlot()] = dish;
        PlayerPrefs.SetInt(dish.name, 1);
        if (onDiscoveryChangeCallBack != null)
            onDiscoveryChangeCallBack.Invoke();
    }

    public int EmptySlot()
    {
        for (int i = 0; i < recipeFound.Length; i++)
        {
            if (!recipeFound[i])
            {
                return i;
            }
        }
        return recipeFound.Length;
    }


    public bool IsDishDiscovered(Dish _dish)
    {
        foreach (Dish dish in recipeFound)
        {
            if (dish)
            {
                if (dish.name == _dish.name)
                {
                    Debug.Log(dish.name + " aleady exists");
                    return true;
                }
            }
        }
        return false;
        
    }

    public int CountDiscoveredRecipe()
    {
        int count = 0;
        foreach (Dish dish in recipeFound)
        {
            if (dish)
            {
                count += 1;
            }
        }
        return count;
    }


    public void EnableNewRecipePanel(Dish _dish)
    {
        NewRecipePanel.SetActive(true);
        FoundRecipePanel.SetActive(true);
        discoveryDisplay.dish = _dish;
        discoveryDisplay.Setup();
        AudioManager.instance.Play("craft");
    }





}
