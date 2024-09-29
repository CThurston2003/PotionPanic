using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 1f; //Variable to control mouse sensitivity

    public Transform player; //reference to players body

    float xRotation = 0f; //Rotation value to apply to players transform to rotate around the y axis

    public PlayerInput playerInput; //reference to player input object
    private InputAction lookAction; //Creating object to store look input actions in

    void Awake(){

        //Referencing the look actions and tying it to the script
        lookAction = playerInput.actions["MouseLook"];


    }


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void mouseLook(InputAction.CallbackContext context){

        float mouseX = lookAction.ReadValue<Vector2>().x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookAction.ReadValue<Vector2>().y * mouseSensitivity * Time.deltaTime;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90f,90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);

        //Debug.Log(mouseX);
        Debug.Log(Vector3.up * mouseX * Time.deltaTime);
        

    }

    //Fixed update function
    void FixedUpdate(){

       


    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
