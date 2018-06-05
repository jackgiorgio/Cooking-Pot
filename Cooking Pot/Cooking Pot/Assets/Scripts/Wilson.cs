using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Wilson : MonoBehaviour, IDropHandler{

    private Animator anim;
    public GameObject itemObj;

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
            }
            else if (value < 0)
            {
                health = 0;
            }
            else
            {
                health = value;
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
            }
            else if (value < 0)
            {
                hunger = 0;
            }
            else
            {
                hunger = value;
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
            }
            else if (value < 0)
            {
                sanity = 0;
            }
            else
            {
                sanity = value;
            }
        }
    }

    private void Start()
    {
        Health = 0;
        Hunger = 0;
        Sanity = 0;
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
