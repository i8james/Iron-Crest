using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{
    [Header("Image Changer Variables")]
    public Image Unit1UI;
    public Image Unit2UI;
    public Image Unit3UI;
    public Image Unit4UI;
    public Image CurrentUnitImage;
    public Image SelectedUnitsImage;
    private Sprite Unit1SourcePicture;
    private Sprite Unit2SourcePicture;
    private Sprite Unit3SourcePicture;
    private Sprite Unit4SourcePicture;
    private Sprite SelectedUnitPicture;

    [Header("Text Changing Variables")]
    public TMP_Text HealthText;
    public int CurrentUnitHealth;
    public int CurrentUnitMaxHealth;
    public TMP_Text SpeedText;
    public int CurrentUnitSpeed;

    [Header("Weapon 1")]
    public TMP_Text W1NameField;
    public string Weapon1Name;
    public TMP_Text W1Attack;
    public int W1AttackValue;
    public TMP_Text W1Range;
    public int W1RangeValue;

    [Header("Weapon 2")]
    public TMP_Text W2NameField;
    public string Weapon2Name;
    public TMP_Text W2Attack;
    public int W2AttackValue;
    public TMP_Text W2Range;
    public int W2RangeValue;
    
    void Start()
    {

    }
    void Update()
    {
        GettingImages();
        GettingText();
    }
    void GettingImages()
    {
        Unit1SourcePicture = Unit1UI.GetComponent<Image>().sprite;
        Unit2SourcePicture = Unit2UI.GetComponent<Image>().sprite;
        Unit3SourcePicture = Unit3UI.GetComponent<Image>().sprite;
        Unit4SourcePicture = Unit4UI.GetComponent<Image>().sprite;
    }
    void GettingText()
    {
        //Top Rows text
        HealthText.text = CurrentUnitHealth.ToString() + "/" + CurrentUnitMaxHealth.ToString() + " HP";
        SpeedText.text = "Speed: " + CurrentUnitSpeed.ToString();
        //Weapon 1
        W1NameField.text = Weapon1Name;
        W1Attack.text = "Attack: " + W1AttackValue.ToString();
        W1Range.text = "Range: " + W1RangeValue.ToString();
        //Weapon 2
        W2NameField.text = Weapon2Name;
        W2Attack.text = "Attack: " + W2AttackValue.ToString();
        W2Range.text = "Range: " + W2RangeValue.ToString();
    }
    public void iHaveBeenSelectedUnit1()
    {
        //Sets the to be selected image to the button pressed
        //Changes the image
        CurrentUnitImage.sprite = Unit1SourcePicture;

        //Changes Unit Specific Stats to preset intigers
        CurrentUnitHealth = 5;
        CurrentUnitMaxHealth = 10;
        CurrentUnitSpeed = 5;
        
        //Changes Weapon 1
        Weapon1Name = "Punch";
        W1AttackValue = 3;
        W1RangeValue = 1;

        //Changes Weapon 2
        Weapon2Name = "Christmas Spirit";
        W2AttackValue = 1;
        W2RangeValue = 5;
    }
    public void iHaveBeenSelectedUnit2()
    {
        //Sets the to be selected image to the button pressed
        //Changes the image
        CurrentUnitImage.sprite = Unit2SourcePicture;

        //Changes Unit Specific Stats to preset intigers
        CurrentUnitHealth = 5;
        CurrentUnitMaxHealth = 10;
        CurrentUnitSpeed = 5;

        //Changes Weapon 1
        Weapon1Name = "Kick";
        W1AttackValue = 2;
        W1RangeValue = 2;

        //Changes Weapon 2
        Weapon2Name = "Spirit";
        W2AttackValue = 2;
        W2RangeValue = 100;
    }
    public void iHaveBeenSelectedUnit3()
    {
        //Sets the to be selected image to the button pressed
        //Changes the image
        CurrentUnitImage.sprite = Unit3SourcePicture;

        //Changes Unit Specific Stats to preset intigers
        CurrentUnitHealth = 6;
        CurrentUnitMaxHealth = 12;
        CurrentUnitSpeed = 10;

        //Changes Weapon 1
        Weapon1Name = "Headbutt";
        W1AttackValue = 12;
        W1RangeValue = 1;

        //Changes Weapon 2
        Weapon2Name = "Regifting";
        W2AttackValue = 3;
        W2RangeValue = 4;
    }
    public void iHaveBeenSelectedUnit4()
    {
        //Sets the to be selected image to the button pressed
        //Changes the image
        CurrentUnitImage.sprite = Unit4SourcePicture;

        //Changes Unit Specific Stats to preset intigers
        CurrentUnitHealth = 5;
        CurrentUnitMaxHealth = 10;
        CurrentUnitSpeed = 5;

        //Changes Weapon 1
        Weapon1Name = "Knee";
        W1AttackValue = 3;
        W1RangeValue = 1;

        //Changes Weapon 2
        Weapon2Name = "Gore";
        W2AttackValue = 1;
        W2RangeValue = 5;
    }
}
