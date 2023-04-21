using System.Collections;
using System;
using UnityEditor;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Determines what type of button it is when clicked
    public void LoadScene(string sceneName)
    {
        Debug.Log("Loading" + sceneName);
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void LoadMainScreen()
    {
        Debug.Log("Loading Main Menu");
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void LoadInfoScreen()
    {
        Debug.Log("Loading Info Screen");
        SceneManager.LoadSceneAsync("InfoScreen");
    }

    //Will quit the program if is opened as an application.
    public void Quit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {

    }
}