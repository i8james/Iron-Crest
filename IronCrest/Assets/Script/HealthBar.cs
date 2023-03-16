using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public GameObject target;

    public int health;

    public float maxHealth;

    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*

        if(target.GetComponent<UnitMovement>())
        {
            playerUpdateHealth();
        }

        if(healthBar.value < health)
        {
            healthBar.value -= 1 * Time.deltaTime;
        }*/
    }

    void playerUpdateHealth()
    {
        /*
        //healthBar.maxValue = 100;
        health = target.GetComponent<UnitMovement>().health;
        healthBar.value = health;*/
    }


   /* IEnumerator ReduceHealth()
    {
        //for (int h = health; h < )
        {
            healthBar.value -= 1 * Time.deltaTime;
            return 
        }
    }*/
}
