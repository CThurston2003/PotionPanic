//Name: Caleb Thurston
//Description: Script to deal with the player looking around with the mouse
//Language: C#
//Part of Project: Potion Panic

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{

    //------------------------------Variables Section-------------------------------------------

    [SerializeField] private float mouseSensitivity = 1f; //Variable to control mouse sensitivity

    [SerializeField] private Transform player; //reference to players body

    private float xRotation = 0f; //Rotation value to apply to players transform to rotate around the y axis

    [SerializeField] private PlayerInput playerInput; //reference to player input object
    private InputAction lookAction; //Creating object to store look input actions in
    
    //floats to store the mouseX and Y values from the mouse
    private float mouseX;
    private float mouseY;

    //Awake function
    void Awake(){

        //Referencing the look actions and tying it to the script
        lookAction = playerInput.actions["MouseLook"];


    }


    // Start is called before the first frame update
    void Start()
    {

        //Locking the cursor to the screen while playing the game
        Cursor.lockState = CursorLockMode.Locked;
    }

    //Function to deal with first person view
    public void mouseLook(InputAction.CallbackContext context){

        //Storing vector 2 values corresponding to the x and y that the player is looking
        mouseX = lookAction.ReadValue<Vector2>().x * mouseSensitivity * Time.deltaTime;
        mouseY = lookAction.ReadValue<Vector2>().y * mouseSensitivity * Time.deltaTime;
        
        
        //Storing the value of Y to correspond to rotation along the y axis, so rotating left and right
        xRotation -= mouseY;
        //Clamping the values so the player cant look farther than 90 degrees up or down
        xRotation = Mathf.Clamp(xRotation,-90f,90f);

        //Rotating the camera by rotating its transform component relative to its current position, and rotating the players body using a vector 3 value passed into the Rotate function
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);

    }

    //Fixed update function
    void FixedUpdate(){

        Debug.DrawRay(transform.position, transform.forward * 10);

    }
    
    
    // Update is called once per frame
    void Update(){
        
    }
}
