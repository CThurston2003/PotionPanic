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

    [SerializeField] private float _mouseSensitivity = 1f; //Variable to control mouse sensitivity
    //Making mouseSensitivity property
    public float MouseSensitivity{
        get{
            return _mouseSensitivity;
        }
        set{
            _mouseSensitivity = value;
        }
    }

    [SerializeField] private Transform player; //reference to players body

    private float _xRotation = 0f; //Rotation value to apply to players transform to rotate around the y axis
    //Making the XRotation property
    public float XRotation{
        get{
            return _xRotation;
        }
        set{
            if(value >= -90f && value <= 90f){
                _xRotation = value;
            }
        }
    }

    [SerializeField] private PlayerInput playerInput; //reference to player input object
    private InputAction lookAction; //Creating object to store look input actions in
    
    //floats to store the MouseX and Y values from the mouse
    private float _mouseX;
    private float _mouseY;
    //Properties for mouseX and mousey
    public float MouseX{get; set;}
    public float MouseY{get; set;}

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
    public void mouseLook(){

        //Storing vector 2 values corresponding to the x and y that the player is looking
        MouseX = lookAction.ReadValue<Vector2>().x * MouseSensitivity;
        MouseY = lookAction.ReadValue<Vector2>().y * MouseSensitivity;
        
        
        //Storing the value of Y to correspond to rotation along the y axis, so rotating left and right
        XRotation -= MouseY;
        //Clamping the values so the player cant look farther than 90 degrees up or down

        //Rotating the camera by rotating its transform component relative to its current position, and rotating the players body using a vector 3 value passed into the Rotate function
        transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
        player.Rotate(Vector3.up * MouseX);

    }

    //Fixed update function
    void FixedUpdate(){

        

    }
    
    
    // Update is called once per frame
    void Update(){
        
        mouseLook();

    }
}
