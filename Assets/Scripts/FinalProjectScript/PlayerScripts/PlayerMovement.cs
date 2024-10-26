//Name: Caleb Thurston
//Description: Script to deal with the players movement using a character controller
//Language: C#
//Part of Project: Potion Panic

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    
    //------------------------Variables Section------------------------------
    
    //Reference to the character controller
    [SerializeField] private CharacterController controller;

    //Reference to player's headbob anim
    [SerializeField] private Animator headBob;

    //Reference to the player camera's transform
    [SerializeField] private Transform playerCamera;

    //Movespeed modifier
    [SerializeField] private float _moveSpeed = 1;
    //Making a property for movespeed
    public float MoveSpeed{
        get{
            return _moveSpeed;
        }
        set{
            _moveSpeed = value;
        }
    }

    //Reference to the PlayerInput object
    [SerializeField] private PlayerInput playerInput;

    //Creating an input action object to store player's movement in
    [SerializeField] private InputAction moveAction;

    //Creating an input action object to store the player's jump action in
    [SerializeField] private InputAction jumpAction;

    //Float for Gravity (-9.81 is normal Gravity)
    float _gravity = -29.43f;
    //Making a property for Gravity
    public float Gravity{
        get{
            return _gravity;
        }
        set{
            _gravity = value;
        }
    }

    //Vector3 to store the Velocity of the player
    public Vector3 _velocity;
    //Making a property for velocity
    public Vector3 Velocity{
        get{
            return _velocity;
        }
        set{
            _velocity = value;
        }
    }

    //Transform object used to check if the player is on the ground
    [SerializeField] private Transform groundCheck;

    //Variable to store the radius distance relating to checking how close the player has to get to be considered grounded
    [SerializeField] private float _groundDis = 0.4f;
    //Making a property for groundDis
    public float GroundDis{
        get{
            return _groundDis;
        }
        set{
            _groundDis = value;
        }
    }

    //Layer mask to store all ground objects so the ground check only triggers if it gets close to objects on this layer
    [SerializeField] private LayerMask groundMask;

    //A bool to store whether or not the player is grounded
    bool isGrounded;

    //Variable to store the height the player can jump too
    [SerializeField] private float _jumpHeight = 3f;  
    //Making a property for jumpHeight
    public float JumpHeight{
        get{
            return _jumpHeight;
        }
        set{
            _jumpHeight = value;
        }
    }  
    
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

        //Calling the movement function in the fixed update
        Movement();

    }

    //Function to handle the implementation of player's movement
    void Movement(){

        //Checking if the player is grounded by using Physics.CheckSphere, it greats a sphere around the specified position, and checks if anything on a specific layer mask crosses into 
        //this circle
        isGrounded = Physics.CheckSphere(groundCheck.position,GroundDis,groundMask);

        //Checking if the player is grounded and if they are, allow the person to jump by increasing their Velocity
        if(isGrounded && jumpAction.ReadValue<float>() > 0){
            _velocity.y = Mathf.Sqrt(JumpHeight*(-2)*Gravity);
        }

        //Storing the forward and strafe movements by reading the vector 2 values provided by the moveAction object
        float forward = moveAction.ReadValue<Vector2>().y;
        float strafe = moveAction.ReadValue<Vector2>().x;

        //Making a vector 3 to store transform movement
        Vector3 move = transform.right * strafe + transform.forward * forward;
        
        //Moving the character controller using the vector 3 defined above, times the speed modifier times Time.deltaTime
        controller.Move(move * MoveSpeed * Time.deltaTime);

        //Basic implementation of Gravity by just applying a negative downward force multiplied by Time.deltaTime
        _velocity.y += Gravity * Time.deltaTime;

        //Resetting the Velocity whenever the player is grounded so Velocity isn't forever building up
        if(isGrounded && _velocity.y < 0){
            _velocity.y = -2.0f;
        }

        //applying Gravity to the player using the character controller move method        
        controller.Move(_velocity*Time.deltaTime);

        //If statement to read if the player is moving by reading their x and z value
        if(move.x != 0 || move.z != 0){
            
            // isBob = true;
            headBob.SetFloat("Bob2",1f);

        }else if (move.x == 0 && move.z == 0){

            headBob.SetFloat("Bob2",0f);

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
