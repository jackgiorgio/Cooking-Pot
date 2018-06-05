using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDisplay : MonoBehaviour {

	public Item item;
	public Image icon;
	public TextMeshProUGUI nameText;
    public int Amount
    {
        get
        {
            return amount;
        }
        set
        {
            amount = value;
            if (amount == 1)
            {
                amountText.text = "";
            }
            else
            {
                amountText.text = value.ToString();
            }
            
        }
    }



    protected int amount = 1;
    public TextMeshProUGUI amountText;

    private void Start()
    {
        Setup(item);
        Amount = amount;
    }
    public void Setup (Item _item)
	{
		item = _item;
		icon.sprite = item.icon;
		nameText.text = item.name;
	}

    public void Stack(int _amount)
    {
        Amount += _amount;
    }

}