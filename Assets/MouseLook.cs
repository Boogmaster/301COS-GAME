using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //declares a variable for the mouse sensitivity
    public float mouseSensitivity = 100f;
    //declares a player body for rotation
    public Transform playerBody;
    //declares a float for x rotation
    float xRotation = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        //hides the cursor and locks to the middle of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //declares and assigns the values for the x and y movment (Time.deltaTime is time since last update)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //decrease rotation every frame
        xRotation -= mouseY;
        
        //clamps the maximum rotation 
        xRotation = Mathf.Clamp(xRotation,-90f, 90f);

        //applies the rotation - uses this method so clamping can be done
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); 
        
        //moves the player from side to side
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
