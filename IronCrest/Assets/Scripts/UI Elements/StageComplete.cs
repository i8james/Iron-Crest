using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageComplete : MonoBehaviour
{
    public GameObject completionScreen;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        GameManager.OnGameStateChanged += GameStateUpdate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GameStateUpdate(GameState newState)
    {
        if(newState == GameState.StageComplete)
        {
            gameObject.SetActive(true);
        }
    }

    
}
