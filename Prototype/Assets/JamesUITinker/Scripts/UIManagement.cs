using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{
    public Image Unit1UI;
    public Image Unit2UI;
    public Image Unit3UI;
    public Image Unit4UI;
    public Image SelectedUnitUI;
    private Sprite Unit1SourcePicture;
    private Sprite Unit2SourcePicture;
    private Sprite Unit3SourcePicture;
    private Sprite Unit4SourcePicture;
    private Sprite SelectedUnitPicture;

    // Start is called before the first frame update
    void Start()
    {
        SelectedUnitPicture = SelectedUnitUI.SourceImage;1
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Get each bird(Unit) image
    //Gets the selected ui image to change based on bird button pressed.
}
