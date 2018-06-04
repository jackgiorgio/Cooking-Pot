using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DishDisplay : FoodDisplay {

    public Dish dish;

    public void SetUpItem()
    {
        item.name = dish.name;
        item.icon = dish.icon;
    }
}
