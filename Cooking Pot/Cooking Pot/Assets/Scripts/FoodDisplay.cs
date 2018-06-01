using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodDisplay : MonoBehaviour
{

    public Food food;
    public Image icon;
    public TextMeshProUGUI nameText;

    private void Start()
    {
        Setup(food);
    }
    public void Setup(Food _food)
    {
        food = _food;
        icon.sprite = food.icon;
        nameText.text = food.name;
    }

}
