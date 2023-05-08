using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float timeStamp;

    float timeElapsed;

    private bool locked;

    float horizontalInput;

    

    private Vector3 end;

    // Start is called before the first frame update
    void Start()
    {
        timeStamp = 0f;
        locked = false;
    }

    // Update is called once per frame
    void Update()
    {

        //if (timeStamp <= Time.time)
        //{
        
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0 && !locked)
        {
            end = transform.position + (Vector3.right * horizontalInput);
            StartCoroutine(Timer(transform.position, end));
            
            transform.position = end;
            locked = false;
        }
        
        
    }

    void glide(float a, float b)
    {
        locked = true;
        
        
        while (timeElapsed < 0.2f)  
        {
            float value = Mathf.Lerp(a, b, timeElapsed / 0.2f);
            transform.position += (Vector3.right * value);
            timeElapsed += Time.deltaTime;
        }
        if (timeElapsed == 0.2f)
        {
            locked = false;
        }
        
    }

    private IEnumerator Timer(Vector3 a, Vector3 b)
    {
        locked = true;
        timeElapsed = 0f;
        while (timeElapsed < 0.2f)
        {
            transform.position = Vector3.Lerp(a, b, (timeElapsed / 0.2f));
            timeElapsed += Time.deltaTime;
        }
        yield return new WaitForSeconds(0.2f);
    }


}
