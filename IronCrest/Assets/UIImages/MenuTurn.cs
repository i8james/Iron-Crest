using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTurn : MonoBehaviour
{
    public bool mouseOver;

    public int identity;

    public float rotationSpeed;

    private Quaternion initRot;

    // Start is called before the first frame update
    void Start()
    {
        initRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        switch (identity)
        {
            case 0:
                if(mouseOver)
                {
                    transform.Rotate(0, - rotationSpeed * Time.deltaTime, 0);
                    break;
                } else
                {
                    break;
                }
            case 1:
                transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
                break;


        }
    }

    public void resetRot()
    {
        transform.rotation = initRot;
    }
}
