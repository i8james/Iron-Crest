using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraShmoove : MonoBehaviour
{
    public GameObject cam;

    public float moveSpeed;
    public float zoomSpeed;
    public float minZoomDist;
    public float maxZoomDist;
    public float rotationSpeed;
    public float X;
    public float Y;
    public float minX = 0;
    public float maxX = 80f;

    public bool lockedCam;

    private GameState currentState;


    // Start is called before the first frame update
    void Start()
    {
        lockedCam = false;
        GameManager.OnGameStateChanged += OnGameStateChange;
        EventManager.SendCamLock += CamLockStatus;
    }

    // Update is called once per frame
    void Update()
    {

        if (!lockedCam)
        {
            /*if (GameManager.Instance.activeUnit != null && (currentState == GameState.EnemyMove))
            {
                FocusOnPosition(GameManager.Instance.activeUnit.transform.position);
            }*/
            Move();
            

        } else if (GameManager.Instance.activeUnit != null)
            {
                FocusOnPosition(GameManager.Instance.activeUnit.transform.position);
            }

        Rotate();
        Zoom();
        
    }

    private void CamLockStatus(bool newLock)
    {
        lockedCam = newLock;
    }

    void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(transform.forward.x, 0, transform.forward.z) * zInput + new Vector3(cam.transform.right.x, transform.right.y, cam.transform.right.z) * xInput;
        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    void Zoom()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        float dist = Vector3.Distance(transform.position, cam.transform.position);
        if (dist < minZoomDist && scrollInput > 0.0f)
            return;
        else if (dist > maxZoomDist && scrollInput < 0.0f)
            return;
        cam.transform.position += cam.transform.forward * scrollInput * zoomSpeed;
    }

    public void FocusOnPosition(Vector3 pos)
    {
        transform.position = pos;
    }

    void Rotate()
    {
        if (Input.GetMouseButton(1))
        {
            
            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * rotationSpeed, -Input.GetAxis("Mouse X") * rotationSpeed, 0));
            if (transform.rotation.eulerAngles.x <= maxX && transform.rotation.eulerAngles.x >= minX)
            {
                X = transform.rotation.eulerAngles.x;
            }
            Y = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(X, Y, 0);
      
        }
    }

    public void OnGameStateChange(GameState newState)
    {
        currentState = newState;
        if (GameManager.Instance.activeUnit != null)
        {
            FocusOnPosition(GameManager.Instance.activeUnit.transform.position);
        }
        if(newState == GameState.PlayerSelect)
        {
        
           
            
        }
    }
}


/*void Start()
    {
        lockedCam = false;
        GameManager.OnGameStateChanged += OnGameStateChange;
        EventManager.SendCamLock += CamLockStatus;
    }

    // Update is called once per frame
    void Update()
    {

        if (!lockedCam)
        {
            if (GameManager.Instance.activeUnit != null && (currentState == GameState.EnemyMove))
            {
                FocusOnPosition(GameManager.Instance.activeUnit.transform.position);
            }
            Move();
            Rotate(); 

        } else if (GameManager.Instance.activeUnit != null)
            {
                FocusOnPosition(GameManager.Instance.activeUnit.transform.position);
            }
        

        Zoom();
        
    }

    private void CamLockStatus(bool newLock)
    {
        lockedCam = newLock;
    }

    void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(cam.transform.forward.x, transform.forward.y, cam.transform.forward.z) * zInput + new Vector3(cam.transform.right.x, transform.right.y, cam.transform.right.z) * xInput;
        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    void Zoom()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        float dist = Vector3.Distance(transform.position, cam.transform.position);
        if (dist < minZoomDist && scrollInput > 0.0f)
            return;
        else if (dist > maxZoomDist && scrollInput < 0.0f)
            return;
        cam.transform.position += cam.transform.forward * scrollInput * zoomSpeed;
    }

    public void FocusOnPosition(Vector3 pos)
    {
        transform.position = pos;
    }

    void Rotate()
    {
        if (Input.GetMouseButton(1))
        {
            
            cam.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * rotationSpeed, -Input.GetAxis("Mouse X") * rotationSpeed, 0));
            if (cam.transform.rotation.eulerAngles.x <= maxX && cam.transform.rotation.eulerAngles.x >= 0)
            {
                X = cam.transform.rotation.eulerAngles.x;
            }
            Y = cam.transform.rotation.eulerAngles.y;
            cam.transform.rotation = Quaternion.Euler(X, Y, 0);
      
        }
    }

    public void OnGameStateChange(GameState newState)
    {
        currentState = newState;
        if (GameManager.Instance.activeUnit != null)
        {
            FocusOnPosition(GameManager.Instance.activeUnit.transform.position);
        }
    }*/