using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridStats : MonoBehaviour
{
    public int visited = -1;
    public int x = 0;
    public int y = 0;

    public GameObject arrow;

    public bool arrowActive;

    // Start is called before the first frame update
    void Start()
    {
        arrow.SetActive(false);
        arrowActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(arrowActive)
        {
            
                arrow.SetActive(true);
                

        } else
        {
            
            arrow.SetActive(false);
           
        }
    }
}
