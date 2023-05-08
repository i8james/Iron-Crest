using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatMessage : MonoBehaviour
{
    public Transform target;

    public float offSet;

    public TextMeshProUGUI input;


    // Start is called before the first frame update
    void Start()
    {
        offSet = 0f;
        
    }

    public void SetText(string newInput)
    {
        input.SetText(newInput);
    }

    // Update is called once per frame
    void Update()
    {
        if (offSet <= 1f)
        {
            var wantedPos = Camera.main.WorldToScreenPoint(target.position + new Vector3(0, offSet, 0));
            transform.position = wantedPos;
            offSet += 1 * Time.deltaTime;
        } else
        {
            Destroy(gameObject);
        }
    }



}
