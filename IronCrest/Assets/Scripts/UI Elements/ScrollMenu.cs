using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollMenu : MonoBehaviour
{


    public GameObject buttonParent;
    public List<GameObject> buttons = new List<GameObject>();

    public GameObject buttonCatagoryParent; 


    public GameObject chest;
    public GameObject head;

    public Scrollbar scroll;

    public Scrollbar catScroll;




    // Start is called before the first frame update
    void Start()
    {
        SpawnButtons();
        SpawnCatagoryButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void SpawnCatagoryButtons() {
        catScroll.numberOfSteps = buttons.Count / 4;

        for (int i = 0; i < buttons.Count; i ++) {
            Instantiate(buttons[i], buttonCatagoryParent.transform);
        }
    }

    private void SpawnButtons() {
        scroll.numberOfSteps = buttons.Count;
        for(int i = 0; i < buttons.Count; i ++) {
            Instantiate(buttons[i], buttonParent.transform);
        }
    }
}
