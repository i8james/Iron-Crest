/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Units : MonoBehaviour
{
    public List<GameObject> player = new List<GameObject>();
    public List<GameObject> enemy = new List<GameObject>();
    void awake()
    {
        DontDestroyOnLoad(GameManager);
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

    public void destroyUnit(GameObject unit, bool ally)
    {
        if (ally)
        {
            player.Remove(unit);
        }
        else
        {
            enemy.Remove(unit);
        }
        Destroy(unit);
    }
}
*/