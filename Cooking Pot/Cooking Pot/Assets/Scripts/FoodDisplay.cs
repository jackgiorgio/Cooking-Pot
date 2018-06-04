using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodDisplay : ItemDisplay
{
    public Food food;
    public float perishTime;
    public Image backFrame;
    public Image background;
    public Color orange;
    public Color darkGreen;
    public Color darkRed;

    [SerializeField]
    private float percentage = 1f;

    public float Percentage
    {
        get
        {
            return percentage;
        }
        set
        {
            percentage = value;
            Debug.Log(percentage);
            background.fillAmount = percentage;
            if (percentage > 0.6)
            {
                backFrame.color = darkGreen;
                background.color = darkGreen;
            }
            if (percentage > 0.3 & percentage<0.6)
            {
                backFrame.color = new Color(orange.r,orange.g,orange.b,orange.a);
                background.color = orange;
            }
            if (percentage < 0.3)
            {
                backFrame.color = darkRed;
                background.color = darkRed;
            }

        }
    }

    void Start()
    {
        icon.sprite = item.icon;
        nameText.text = item.name;
        perishTime = food.perish * 480;
        if (amount == 1)
        {
            amountText.text = "";
        }
        if (perishTime > 0 & food.perish !=0)
        {
            CountTime(perishTime);
        }
        
    }


    public void CountTime(float time)
    {
        perishTime = time;
        StartCoroutine(UpdatePerishTime());
    }

    private IEnumerator UpdatePerishTime()
    {
        while (perishTime > 0)
        {
            perishTime -= 1;
            Percentage =1- (food.perish * 480 - perishTime) / (food.perish * 480);
            yield return new WaitForSeconds(1f);
        } 
    }

}
