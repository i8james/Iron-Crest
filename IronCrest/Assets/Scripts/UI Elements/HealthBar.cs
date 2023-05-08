using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{

    public Transform target;

    public int health;

    public float maxHealth;

    public Slider healthBar;

    public Unit owner;

    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetOwner(Unit newOwner, Transform newPos)
    {
        target = newPos;
        owner = newOwner;
        healthBar.maxValue = owner.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        

        /*if(target.GetComponent<UnitMovement>())
        {
            playerUpdateHealth();
        }*/

        if (owner)
        {
            healthBar.maxValue = owner.maxHealth;
            healthBar.value = owner.health;
            healthText.text = owner.health.ToString();
            var wantedPos = Camera.main.WorldToScreenPoint(owner.healthBarPoint.position);
            transform.position = wantedPos;
        } else
        {
            Destroy(gameObject);
        }

        /*if(healthBar.value < health)
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
