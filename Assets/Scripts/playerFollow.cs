//This script is used make the player's "body" follow the players "head"


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerFollow : MonoBehaviour
{
    
    private PlayerInput playerInput; //creating a variable for the player input object
    private InputAction moveAction; //Creating an InputAction object to reference movements from the player
    private Rigidbody rigidBody; //Creating a rigidBody opject to reference players rigidbody
    public float moveFactor; //The factor that the players movement is multiplied by
    public Transform playerBody; //Reference to the transform of the player body
    private InputAction lookAction; //Creating an InputAction object to reference the players view

    //Awake function
    private void Awake(){

        //Tying the player input object to the script through this reference
        playerInput = GetComponent<PlayerInput>();
        
        //Referencing the movement actions and tying it to the script
        moveAction = playerInput.actions["Move"];

        //Referencing the look actions and tying it to the script
        lookAction = playerInput.actions["Look"];


    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Fixed update function
    void FixedUpdate(){

        //Debug.Log(moveAction.ReadValue<Vector2>().x);

        Vector3 movement = new Vector3(0f,0f,lookAction.ReadValue<Vector2>().y * moveAction.ReadValue<Vector2>().y);
        playerBody.Translate(movement, playerBody);

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
