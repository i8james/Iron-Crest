using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using DG.Tweening;

public class HealthBar : MonoBehaviour
{
    /*public Image healthBarImage;
    public Unit unit;
    Quaternion startRotation;
    //has the update change when damage is taken
    //this is the function name to use to change the units health bar.
    //please change the variables if needed.
    public void UpdateHealthBar()
    {
        float duration = 0.75f * (unit.health / unit.maxHealth);
        healthBarImage.fillAmount = Mathf.Clamp(unit.health / unit.maxHealth, duration);
        //healthBarImage.DOFillAmount( unit.health / unit.maxHealth, duration);

        Color newColor = Color.green;
        if (unit.health < unit.maxHealth * 0.25f)
        {
            newColor = Color.red;
        }
        else if (unit.health < unit.maxHealth * 0.66f)
        {
            newColor = new Color(1f, .64f, 0f, 1f);
        }
        healthBarImage.Color(newColor, duration);
        //healthBarImage.DOColor(newColor, duration);
    }
    //These keep the health bar facing one direction
    void Start()
    {
        startRotation = transform.rotation;
    }
    void Update()
    {
        transform.rotation = startRotation;
    }*/
}
