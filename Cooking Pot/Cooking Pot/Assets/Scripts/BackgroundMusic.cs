using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour {

    public string backgroundMusic;

	// Use this for initialization
	void Start () {
        AudioManager.instance.Play(backgroundMusic);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Stop()
    {
        AudioManager.instance.Stop(backgroundMusic);
    }
}
