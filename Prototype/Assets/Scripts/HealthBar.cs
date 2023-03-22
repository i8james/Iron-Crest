using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public Unit unit;
    //has the update change when damage is taken
    //this is the function name to use to change the units health bar.
    public void UpdateHealthBar()
    {
        healthBarImage.fillAmount = Mathf.Clamp(unit.health / unit.maxHealth, 0, 1f);
    }
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
