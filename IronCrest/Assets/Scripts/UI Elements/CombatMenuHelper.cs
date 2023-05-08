using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMenuHelper : MonoBehaviour
{
    public GameObject canvas;

    public GameObject healthBarPrefab;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.SendHealthBarPos += PlaceHealthBar;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void PlaceHealthBar(Transform healthPos, Unit newUnit)
    {
        GameObject newHealthBar = Instantiate(healthBarPrefab, canvas.transform);
        newHealthBar.GetComponentInChildren<HealthBar>().SetOwner(newUnit, healthPos);
        //newHealthBar.GetComponentInChildren<HealthBarPos>().target = healthPos;
    }


}
