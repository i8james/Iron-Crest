using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollList : MonoBehaviour
{
   
    
    public float gapLength;
  

   // public List<PartSelectButton> partsList = new List<PartSelectButton>();

    public List<GameObject> games = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        ReceiveNewPartsList(games);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void ReceiveNewPartsList(List<GameObject> newPartsList)
    {
        //   partsList.Clear();
        print("Adding Button");

        float size = newPartsList[0].GetComponent<Renderer>().bounds.size.y;

        for (int i = 0; i < newPartsList.Count; i++)
        {
            
            if(i == 0)
            {
                GameObject newButton = Instantiate(newPartsList[0], this.gameObject.transform);
                newButton.transform.position = Vector3.zero + Vector3.up * (-size / 2);
              //  partsList.Add(newButton.GetComponent<PartSelectButton>());
            } else
            {
                GameObject newButton = Instantiate(newPartsList[i], this.gameObject.transform);
                newButton.transform.position = Vector3.up * ((-size * i) + (gapLength * i));
                
            }
        }
    }
}
