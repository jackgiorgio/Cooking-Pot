using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float timeOfSplash;

    public void Start()
    {
        if (timeOfSplash != 0)
        {
            Invoke("LoadNextLevel", timeOfSplash);
        }

    }

    public void LoadLevel(string name)
    {

        AudioManager.instance.Play("Clip");
        Debug.Log("New Level load: " + name);
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        PlayClipEffect();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayClipEffect()
    {
        AudioManager.instance.Play("Clock");
    }

}
