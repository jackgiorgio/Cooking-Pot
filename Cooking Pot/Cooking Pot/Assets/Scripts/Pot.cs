using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pot : MonoBehaviour {

    public enum PotState { cooking,open,idle,finish}
    public GameObject resultPanel;
    public CrafterSlot[] slots;

    private Animator anim;
    public PotState potState = PotState.idle;

    public GameObject craftPanel;
    public Button cookButton;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update () {
        HandlePot();

    }

    public void OpenOrClose()
    {
        if (potState == PotState.idle)
        {
            potState = PotState.open;
            anim.SetTrigger("Open");
            craftPanel.SetActive(true);
            AudioManager.instance.Play("pot_open");
            return; 
        }
        if (potState == PotState.open)
        {
            potState = PotState.idle;
            anim.SetTrigger("Close");
            craftPanel.SetActive(false);
            AudioManager.instance.Play("pot_close");

        }
    }

    public void Cook(float time)
    {
        if (potState == PotState.open)
        {
            foreach(CrafterSlot cs in slots)
            {
                cs.RemoveItem(cs.slot);
            }
            potState = PotState.cooking;
            anim.SetTrigger("Cook");
            StartCoroutine(Harvest(1.0f));
        }
    }

    public IEnumerator Harvest(float time)
    {
        yield return new WaitForSeconds(time);

        anim.SetTrigger("Finish");

    }

    public void HandlePot()
    {
        if (resultPanel.transform.childCount == 1 & potState == PotState.cooking)
        {
            potState = PotState.finish;
        }

        if (resultPanel.transform.childCount == 0 & potState == PotState.finish)
        {
            potState = PotState.idle;
            anim.SetTrigger("Close");
        }

        foreach (CrafterSlot s in slots)
        {
            if (!s.itemObj)
            {
                cookButton.interactable = false;
            }
            else
            {
                cookButton.interactable = true;
            }
        }
    }

}
