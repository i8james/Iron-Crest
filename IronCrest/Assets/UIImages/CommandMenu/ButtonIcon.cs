using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonIcon : MonoBehaviour
{

    public Sprite icon;

    public Image buttonImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetButtonVars(Sprite newIcon)
    {
        icon = newIcon;
        buttonImage.sprite = newIcon;
    }
}
