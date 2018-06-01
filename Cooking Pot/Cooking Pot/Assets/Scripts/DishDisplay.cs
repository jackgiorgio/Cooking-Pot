using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DishDisplay : MonoBehaviour {

    public Dish dish;
    public Image icon;
    public TextMeshProUGUI nameText;

    private void Start()
    {
        Setup(dish);
    }
    public void Setup(Dish _dish)
    {
        dish = _dish;
        icon.sprite = dish.icon;
        nameText.text = dish.name;
    }
}
