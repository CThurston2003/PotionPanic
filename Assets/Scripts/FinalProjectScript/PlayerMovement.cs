//Name: Caleb Thurston
//Description: Script to deal with the players movement using a character controller



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    
    //Reference to the character controller
    public CharacterController controller;

    //Movespeed modifier
    public float moveSpeed = 1;

    //Reference to the PlayerInput object
    public PlayerInput playerInput;

    //Creating an input action object to store player's movement in
    public InputAction moveAction;

    //Creating an input action object to store the player's jump action in
    public InputAction jumpAction;

    //Float for gravity (-9.81 is normal gravity)
    float gravity = -29.43f;

    //Vector3 to store the velocity of the player
    Vector3 velocity;

    //Transform object used to check if the player is on the ground
    public Transform groundCheck;

    //Variable to store the radius distance relating to checking how close the player has to get to be considered grounded
    public float groundDis = 0.4f;

    //Layer mask to store all ground objects so the ground check only triggers if it gets close to objects on this layer
    public LayerMask groundMask;

    //A bool to store whether or not the player is grounded
    bool isGrounded;

    //Variable to store the height the player can jump too
    public float jumpHeight = 3f;
    
    
    //Awake function
    void Awake(){

        //Making code easier by storing the move actions and jump actions in its own variable
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];

    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        


    }

    //Fixed Update Function
    void FixedUpdate(){


        //Checking if the player is grounded by using Physics.CheckSphere, it greats a sphere around the specified position, and checks if anything on a specific layer mask crosses into 
        //this circle
        isGrounded = Physics.CheckSphere(groundCheck.position,groundDis,groundMask);

        //Checking if the player is grounded and if they are, allow the person to jump by increasing their velocity
        if(isGrounded && jumpAction.ReadValue<float>() > 0){
            velocity.y = Mathf.Sqrt(jumpHeight*(-2)*gravity);
        }

        //Storing the forward and strafe movements by reading the vector 2 values provided by the moveAction object
        float forward = moveAction.ReadValue<Vector2>().y;
        float strafe = moveAction.ReadValue<Vector2>().x;

        //Making a vector 3 to store transform movement
        Vector3 move = transform.right * strafe + transform.forward * forward;
        
        //Moving the character controller using the vector 3 defined above, times the speed modifier times Time.deltaTime
        controller.Move(move * moveSpeed * Time.deltaTime);

        //Basic implementation of gravity by just applying a negative downward force multiplied by Time.deltaTime
        velocity.y += gravity * Time.deltaTime;

        //Resetting the velocity whenever the player is grounded so velocity isn't forever building up
        if(isGrounded && velocity.y < 0){
            velocity.y = -2.0f;
        }

        //applying gravity to the player using the character controller move method        
        controller.Move(velocity*Time.deltaTime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
