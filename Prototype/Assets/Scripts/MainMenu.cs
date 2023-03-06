using System.Collections;
using System;
using UnityEditor;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool isStart;
    public bool isQuit;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //Determines what type of button it is when clicked
    public void LoadScene(string sceneName)
    {
        LoadScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
