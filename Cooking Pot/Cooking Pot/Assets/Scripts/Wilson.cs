using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Wilson : MonoBehaviour, IDropHandler{

    private Animator anim;
    public GameObject itemObj;
    public Image hungerBar, healthBar, sanityBar;

    [SerializeField]
    private float health;
    [SerializeField]
    private float hunger;
    [SerializeField]
    private float sanity;

    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float maxHunger;
    [SerializeField]
    private float maxSanity;

    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            if (value > maxHealth)
            {
                health = maxHealth;
                healthBar.fillAmount = 1;
            }
            else if (value < 0)
            {
                health = 0;
                healthBar.fillAmount = 0;
            }
            else
            {
                health = value;
                float percentage = value / maxHealth;
                healthBar.fillAmount = percentage;

            }
        }
    }
    public float Hunger
    {
        get
        {
            return hunger;
        }
        set
        {
            if (value > maxHunger)
            {
                hunger = maxHunger;
                hungerBar.fillAmount = 1;
            }
            else if (value < 0)
            {
                hunger = 0;
                hungerBar.fillAmount = 0;
            }
            else
            {
                hunger = value;
                float percentage = value / maxHunger;
                hungerBar.fillAmount = percentage;
            }
        }
    }
    public float Sanity
    {
        get
        {
            return sanity;
        }
        set
        {
            if (value > maxSanity)
            {
                sanity = maxSanity;
                sanityBar.fillAmount = 1;
            }
            else if (value < 0)
            {
                sanity = 0;
                sanityBar.fillAmount = 0;
            }
            else
            {
                sanity = value;
                float percentage = value / maxHunger;
                sanityBar.fillAmount = percentage;
            }
        }
    }

    private void Start()
    {
        Health = 15;
        Hunger = 23;
        Sanity = 40;
        anim = GetComponent<Animator>();
    }

    public void Eat(Food food)
    {
        Health += food.health;
        Hunger += food.hunger;
        Sanity += food.sanity;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");

        if (!itemObj & DragHandler.GetItemBeingDragged().isEatable)
        {
            itemObj = DragHandler.objBeingDragged;
            Debug.Log(itemObj.GetComponent<ItemDisplay>().Amount);
            if (itemObj.GetComponent<ItemDisplay>().Amount > 1)
            {
                Eat(DragHandler.GetFoodBeingDraged());
                anim.SetTrigger("eat");
                itemObj.GetComponent<ItemDisplay>().Amount -= 1;
                itemObj = null;
            }
            else
            {
                itemObj.transform.SetParent(transform);
                itemObj.transform.position = transform.position;

                Eat(DragHandler.GetFoodBeingDraged());
                anim.SetTrigger("eat");
                Destroy(itemObj);
            }
        }
    }





}
