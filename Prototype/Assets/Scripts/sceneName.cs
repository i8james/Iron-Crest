using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class sceneName : MonoBehaviour
{
    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log(scene.name);
    }
}