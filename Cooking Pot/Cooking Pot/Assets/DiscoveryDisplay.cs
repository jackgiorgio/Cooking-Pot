using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiscoveryDisplay : MonoBehaviour {

    public Dish dish;
    public Image icon;
    public TextMeshProUGUI description;



    public void Setup()
    {
        icon.sprite = dish.icon;
        description.text = dish.name;
    }
}
