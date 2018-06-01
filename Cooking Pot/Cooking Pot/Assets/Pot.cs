using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pot : MonoBehaviour {

    public enum PotState { cooking,open,idle,finish}

    private Animator anim;
    public PotState potState = PotState.idle;

    public GameObject craftPanel;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        craftPanel.SetActive(false);
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Open()
    {
        if (potState == PotState.idle)
        {
            potState = PotState.open;
            anim.SetTrigger("Open");
            craftPanel.SetActive(true);
        }
        GetComponent<Button>().interactable = false;

    }

    public void Cook(float time)
    {
        if (potState == PotState.open)
        {
            potState = PotState.cooking;
            anim.SetTrigger("Cook");
            StartCoroutine(Harvest(time));
        }
    }

    public IEnumerator Harvest(float time)
    {
        yield return new WaitForSeconds(time);

        anim.SetTrigger("Finish");

    }





}
