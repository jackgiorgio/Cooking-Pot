using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Wilson : MonoBehaviour, IDropHandler{

    #region Singleton

    public static Wilson instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    private Animator anim;
    public GameObject itemObj;
    public Image hungerBar, healthBar, sanityBar;
    public Text speechText;
    private bool speekTrigger = false;

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
        anim = GetComponent<Animator>();
        Health = 15;
        Hunger = 23;
        Sanity = 40;
    }

    public void Eat(Food food)
    {
        anim.SetTrigger("eat");
        Health += food.health;
        Hunger += food.hunger;
        Sanity += food.sanity;
        StartCoroutine(TackAboutFood());
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");

        //如果物品槽为空，而且可以吃，则吃掉
        if (!itemObj & DragHandler.GetItemBeingDragged().isEatable)
        {
            itemObj = DragHandler.objBeingDragged;
            Debug.Log(itemObj.GetComponent<ItemDisplay>().Amount);
            //如果食品不止一个，则直接减少一个
            if (itemObj.GetComponent<ItemDisplay>().Amount > 1)
            {
                Eat(DragHandler.GetFoodBeingDraged());
                itemObj.GetComponent<ItemDisplay>().Amount -= 1;
                itemObj = null;
            }
            else
            {
                itemObj.transform.SetParent(transform);
                itemObj.transform.position = transform.position;

                Eat(DragHandler.GetFoodBeingDraged());
                Destroy(itemObj);
            }
        }
    }


    private IEnumerator TackAboutFood()
    {
        speechText.text = "I feel better";
        while (!speekTrigger)
        {
            speekTrigger = true;
            yield return new WaitForSeconds(0.8f);
        }
        anim.SetTrigger("speak");
        speekTrigger = false;      
    }

    private void TalkAboutState()
    {
        if (sanity < 30)
        {
            speechText.text = "I don't feel so good";
        }
        if (hunger < 70)
        {
            speechText.text = "I'm starving!";
        }
        else
        {
            speechText.text = "Let's try something new";
        }
        anim.SetTrigger("speak");
        speekTrigger = false;
    }





}
