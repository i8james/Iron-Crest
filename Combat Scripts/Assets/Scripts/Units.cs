using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Units : MonoBehaviour
{
    public List<Unit> player = new List<Unit>();
    public List<Unit> enemy = new List<Unit>();
    // Start is called before the first frame update
    void awake()
    {
        GameManager.DontDestroyOnLoad();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void createUnit(bool ally)
    {
        GameObject newUnit = new GameObject();
        newUnit.AddComponent<Unit>();
        if (ally)
        {
            player.Add(newUnit);
        }
        else
        {
            enemy.Add(newUnit);
        }
    }
}
