using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCrafter : MonoBehaviour
{

	#region Singleton

	public static FoodCrafter instance;

	private void Awake()
	{
		instance = this;
	}

	#endregion

	public Food slot01;
	public Food slot02;
    public Food slot03;
    public Food slot04;

	public Dish[] recipes;

	public Transform resultsParent;
	public GameObject dishPrefab;

	private List<Food> knownItems;

	private void Start()
	{
		recipes = Resources.LoadAll<Dish>("Dishes");
	}

	public void AddItem(Food food, int slot)
	{
		//Debug.Log("Add item to Crafter: " + item.name);
        if(food.cookable)
        {
		    if (slot == 1)
		    {
		    	slot01 = food;
		    } else if (slot == 2)
		    {
		    	slot02 = food;
		    }
            else if (slot == 3)
		    {
		    	slot03 = food;
		    }
            else if (slot == 4)
		    {
		    	slot04 = food;
		    }
        }
        else
        {
            Debug.Log("this food can not be put in pot!");  
        }

	}

	public void RemoveItem(int slot)
	{
		//Debug.Log("Remove from slot " + slot);

		if (slot == 1)
		{
			slot01 = null;
		} else if (slot == 2)
		{
			slot02 = null;
		}
        else if (slot == 3)
		{
			slot03 = null;
		}
        else if (slot == 4)
		{
			slot04 = null;
		}

	}


	public void UpdateResult()
	{
		Dish result = GetResult();
		CreateDish(result);
	}

	void CreateDish (Dish dish)
	{
		GameObject dishObj = Instantiate(dishPrefab, resultsParent);
		DishDisplay display = dishObj.GetComponent<DishDisplay>();
		if (display != null)
			display.Setup(dish);

		//Animator anim = dishObj.GetComponent<Animator>();
		//anim.SetBool("Pickup", false);
	}


	void ClearPreviousResult ()
	{
		foreach (Transform child in resultsParent)
		{
			Destroy(child.gameObject);
		}
	}


    Dish GetResult()
    {
        if (slot01 == null || slot02 == null || slot03 == null || slot04 == null)
        {
            return null;
        }

        List<Dish> dishes = new List<Dish>();

        //add food value
        Dish nd = CreateNewDish();

        if (nd.meat == 0 & nd.veggie > 0 & nd.inedible == 0)
        {
            dishes.Add(SelectDish("Ratatouille"));
        }
        if (nd.banana > 0 & nd.frozen > 0 & nd.inedible > 0 & nd.meat == 0 & nd.fish == 0 & nd.shipWrecked > 0)
        {
            dishes.Add(SelectDish("Banana Pop"));
        }
        if (nd.limpets == 3 & nd.frozen > 0 & nd.shipWrecked > 0)
        {
            dishes.Add(SelectDish("Bisque"));
        }
        if (nd.butterflyWing > 0 & nd.meat == 0 & nd.veggie > 0)
        {
            dishes.Add(SelectDish("Butter Muffin"));
        }
        if (nd.Seaweed == 2 & nd.fish >= 1 & nd.shipWrecked > 0)
        {
            dishes.Add(SelectDish("California Roll"));
        }
        if (nd.fish >= 2 & nd.frozen > 0 & nd.shipWrecked > 0)
        {
            dishes.Add(SelectDish("Ceviche"));
        }
        if ((nd.roastedCoffeeBeans == 4 & nd.shipWrecked > 0) || (nd.roastedCoffeeBeans == 3 & nd.shipWrecked > 0 & (nd.dairy > 0 || nd.sweetener > 0)))
        {
            dishes.Add(SelectDish("Coffee"));
        }
        if (nd.dragonfruit > 0 & nd.meat == 0)
        {
            dishes.Add(SelectDish("Dragonpie"));
        }
        if (nd.dragonfruit > 0 & nd.meat == 0)
        {
            dishes.Add(SelectDish("Dragonpie"));
        }
        if (nd.fish > 0 & nd.corn > 0)
        {
            dishes.Add(SelectDish("Fish Tacos"));
        }
        if (nd.fish > 0 & nd.twigs > 0 & nd.inedible > 0 & nd.inedible <= 1)
        {
            dishes.Add(SelectDish("Fishsticks"));
        }
        if (nd.fruit > 0 & nd.meat == 0 & nd.veggie == 0 & nd.inedible == 1)
        {
            dishes.Add(SelectDish("Fist Full of Jam"));
        }
        if (nd.cactusFlower > 0 & nd.veggie >= 2 & nd.meat == 0 & nd.inedible == 0 & nd.egg == 0 & nd.sweetener == 0 & nd.fruit == 0 & nd.shipWrecked > 0)
        {
            dishes.Add(SelectDish("Flower Salad"));
        }
        if (nd.frogLegs > 0 & nd.veggie >= 0)
        {
            dishes.Add(SelectDish("Froggle Bunwich"));
        }
        if (nd.fruit >= 3 & nd.meat == 0 & nd.veggie == 0)
        {
            dishes.Add(SelectDish("Fruit Medley"));
        }
        if (nd.moleWorm > 0 & nd.cactusFresh > 0 & nd.fruit == 0 & nd.shipWrecked > 0)
        {
            dishes.Add(SelectDish("Guacamole"));
        }
        if (nd.honey > 0 & nd.meat > 1.5f & nd.inedible == 0)
        {
            dishes.Add(SelectDish("Honey Ham"));
        }
        if (nd.honey > 0 & nd.meat <= 1.5f & nd.inedible == 0)
        {
            dishes.Add(SelectDish("Honey Nuggets"));
        }
        if (nd.frozen > 0 & nd.dairy > 0 & nd.sweetener > 0 & nd.meat == 0 & nd.veggie == 0 & nd.inedible == 0 & nd.egg == 0 & nd.reignOfGiants > 0)
        {
            dishes.Add(SelectDish("Ice Cream"));
        }
        if (nd.jellyfish > 0 & nd.frozen > 0 & nd.inedible > 0 & nd.shipWrecked > 0)
        {
            dishes.Add(SelectDish("Jelly-O Pop"));
        }
        if (nd.meat > 0 & nd.twigs > 0 & nd.monster <= 1 & nd.inedible > 0 & nd.inedible <= 1)
        {
            dishes.Add(SelectDish("Kabobs"));
        }
        if (nd.wobster > 0 & nd.frozen > 0 & nd.shipWrecked > 0)
        {
            dishes.Add(SelectDish("Lobster Bisque"));
        }
        if (nd.wobster > 0 & nd.butter > 0 & nd.meat == 0 & nd.frozen == 0 & nd.shipWrecked > 0)
        {
            dishes.Add(SelectDish("Lobster Dinner"));
        }
        if (nd.mandrake > 0)
        {
            dishes.Add(SelectDish("Mandrake Soup"));
        }
        if (nd.meat > 0 & nd.inedible == 0)
        {
            dishes.Add(SelectDish("Meatballs"));
        }
        if (nd.watermelon > 0 & nd.frozen > 0 & nd.twigs > 0 & nd.meat == 0 & nd.veggie == 0 & nd.egg == 0 & nd.reignOfGiants > 0)
        {
            dishes.Add(SelectDish("Melonsicle"));
        }
        if (nd.egg > 0 & nd.meat > 0 & nd.veggie > 0 & nd.inedible == 0)
        {
            dishes.Add(SelectDish("Pierogi"));
        }
        if (nd.twigs > 0 & nd.honey > 0 & nd.corn > 0)
        {
            dishes.Add(SelectDish("Powdercake"));
        }
        if (nd.pumpkin > 0 & nd.sweetener >= 2)
        {
            dishes.Add(SelectDish("Pumpkin Cookie"));
        }
        if (nd.fish > 2 & nd.shipWrecked > 0)
        {
            dishes.Add(SelectDish("Seafood Gumbo"));
        }
        if (nd.sharkFin > 0 & nd.shipWrecked > 0)
        {
            dishes.Add(SelectDish("Shark Fin Soup"));
        }
        if (nd.meat >= 1.5f & nd.veggie >= 1.5f & nd.reignOfGiants > 0)
        {
            dishes.Add(SelectDish("Spicy Chili"));
        }
        if (nd.eggplant > 0 & nd.veggie > 1)
        {
            dishes.Add(SelectDish("Stuffed Eggplant"));
        }
        if (nd.meat >= 2.5 & nd.fish >= 1.5 & nd.reignOfGiants > 0)
        {
            dishes.Add(SelectDish("Surf 'n' Turf"));
        }
        if (nd.sweetener >= 3 & nd.meat == 0)
        {
            dishes.Add(SelectDish("Taffy"));
        }
        if (nd.roastedBirchnut > 0 & nd.seed >= 1 & nd.berries > 0 & nd.fruit >= 1f & nd.meat == 0 & nd.veggie == 0 & nd.egg == 0 & nd.dairy == 0 & nd.reignOfGiants > 0)
        {
            dishes.Add(SelectDish("Trail Mix"));
        }
        if (nd.drumstick > 1 & nd.meat > 1 & (nd.veggie > 0 || nd.fruit > 0))
        {
            dishes.Add(SelectDish("Turkey Dinner"));
        }
        if (nd.lichen > 0 & nd.eel > 0)
        {
            dishes.Add(SelectDish("Unagi"));
        }
        if (nd.butter > 0 & nd.berries > 0 & nd.egg > 0)
        {
            dishes.Add(SelectDish("Waffles"));
        }
        if (nd.egg > 1 & nd.meat > 1 & nd.veggie == 0)
        {
            dishes.Add(SelectDish("Bacon and Eggs"));
        }
        if (nd.meat >= 3 & nd.inedible ==0)
        {
            dishes.Add(SelectDish("Meaty Stew"));
        }
        if (dishes.Count == 0)
        {
            dishes.Add(SelectDish("Wet Goop"));
        }

        Debug.Log(dishes.Count);
        Dish chosenDish = dishes[0];

        if (dishes.Count > 1)
        {
            float max = -1;
            foreach (Dish dish in dishes)
            {
                Debug.Log(dish.priority);
                if (dish.priority > max)
                {
                    max = dish.priority;
                    chosenDish = dish;
                }
            }
        }

        Debug.Log(chosenDish.name);
        return chosenDish;
    }

        Dish CreateNewDish()
        {
            Dish d = ScriptableObject.CreateInstance<Dish>();

            //general type
            d.fruit = slot01.fruit + slot02.fruit + slot03.fruit + slot04.fruit;
            d.egg = slot01.egg + slot02.egg + slot03.egg + slot04.egg;
            d.meat = slot01.meat + slot02.meat + slot03.meat + slot04.meat;
            d.veggie = slot01.veggie + slot02.veggie + slot03.veggie + slot04.veggie;
            d.fish = slot01.fish + slot02.fish + slot03.fish + slot04.fish;
            d.inedible = slot01.inedible + slot02.inedible + slot03.inedible + slot04.inedible;

            //specific type
            d.banana = slot01.banana + slot02.banana + slot03.banana + slot04.banana;
            d.frozen = slot01.frozen + slot02.frozen + slot03.frozen + slot04.frozen;
            d.limpets = slot01.limpets + slot02.limpets + slot03.limpets + slot04.limpets;
            d.butterflyWing = slot01.butterflyWing + slot02.butterflyWing + slot03.butterflyWing + slot04.butterflyWing;
            d.Seaweed = slot01.Seaweed + slot02.Seaweed + slot03.Seaweed + slot04.Seaweed;
            d.roastedCoffeeBeans = slot01.roastedCoffeeBeans + slot02.roastedCoffeeBeans + slot03.roastedCoffeeBeans + slot04.roastedCoffeeBeans;
            d.sweetener = slot01.sweetener + slot02.sweetener + slot03.sweetener + slot04.sweetener;
            d.dragonfruit = slot01.dragonfruit + slot02.dragonfruit + slot03.dragonfruit + slot04.dragonfruit;
            d.corn = slot01.corn + slot02.corn + slot03.corn + slot04.corn;
            d.twigs = slot01.twigs + slot02.twigs + slot03.twigs + slot04.twigs;
            d.cactusFlower = slot01.cactusFlower + slot02.cactusFlower + slot03.cactusFlower + slot04.cactusFlower;
            d.frogLegs = slot01.frogLegs + slot02.frogLegs + slot03.frogLegs + slot04.frogLegs;
            d.moleWorm = slot01.moleWorm + slot02.moleWorm + slot03.moleWorm + slot04.moleWorm;
            d.cactusFresh = slot01.cactusFresh + slot02.cactusFresh + slot03.cactusFresh + slot04.cactusFresh;
            d.honey = slot01.honey + slot02.honey + slot03.honey + slot04.honey;
            d.jellyfish = slot01.jellyfish + slot02.jellyfish + slot03.jellyfish + slot04.jellyfish;
            d.monster = slot01.monster + slot02.monster + slot03.monster + slot04.monster;
            d.wobster = slot01.wobster + slot02.wobster + slot03.wobster + slot04.wobster;
            d.butter = slot01.butter + slot02.butter + slot03.butter + slot04.butter;
            d.mandrake = slot01.mandrake + slot02.mandrake + slot03.mandrake + slot04.mandrake;
            d.watermelon = slot01.watermelon + slot02.watermelon + slot03.watermelon + slot04.watermelon;
            d.pumpkin = slot01.pumpkin + slot02.pumpkin + slot03.pumpkin + slot04.pumpkin;
            d.sharkFin = slot01.sharkFin + slot02.sharkFin + slot03.sharkFin + slot04.sharkFin;
            d.eggplant = slot01.eggplant + slot02.eggplant + slot03.eggplant + slot04.eggplant;
            d.roastedBirchnut = slot01.roastedBirchnut + slot02.roastedBirchnut + slot03.roastedBirchnut + slot04.roastedBirchnut;
            d.seed = slot01.seed + slot02.seed + slot03.seed + slot04.seed;
            d.berries = slot01.berries + slot02.berries + slot03.berries + slot04.berries;
            d.drumstick = slot01.drumstick + slot02.drumstick + slot03.drumstick + slot04.drumstick;
            d.lichen = slot01.lichen + slot02.lichen + slot03.lichen + slot04.lichen;
            d.eel = slot01.eel + slot02.eel + slot03.eel + slot04.eel;
            //dlc

            d.reignOfGiants = slot01.reignOfGiants + slot02.reignOfGiants + slot03.reignOfGiants + slot04.reignOfGiants;
            d.shipWrecked = slot01.shipWrecked + slot02.shipWrecked + slot03.shipWrecked + slot04.shipWrecked;


            d.cookable = false;
        Debug.Log(d.meat);
            return d;
        }

        Dish SelectDish(string dishName)
        {
            foreach (Dish dish in recipes)
            {
                if (dish.name == dishName)
                {
                    return dish;
                }
            }
            return null;
        }
    }


