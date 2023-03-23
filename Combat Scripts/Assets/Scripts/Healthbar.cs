using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public Image healthBarImage;
    GameObject tie = GameObject.Find("Enemy3");
    Enemy enemy = tie.GetComponent<Enemy>();
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = enemy.health;
        currentHealth = maxHealth;

    }
    public void UpdateHealthBar()
    {
        healthBarImage.fillAmount =
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reduceHealth(int damage)
    {

    }
}
