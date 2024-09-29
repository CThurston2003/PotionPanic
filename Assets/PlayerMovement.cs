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
    public PlayerInput playerInput;
    public InputAction moveAction;
    public InputAction jumpAction;
    float gravity = -9.81f;
    Vector3 velocity;
    public Transform groundCheck;
    public float groundDis = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    
    
    //Awake function
    void Awake(){

        //Making code easier by storing the move actions in its own variable
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];

    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Fixed Update Function
    void FixedUpdate(){

        isGrounded = Physics.CheckSphere(groundCheck.position,groundDis,groundMask);

        


        float forward = moveAction.ReadValue<Vector2>().y;
        float strafe = moveAction.ReadValue<Vector2>().x;

        Vector3 move = transform.right * strafe + transform.forward * forward;

        Debug.Log(move);

        
        
        controller.Move(move * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        if(isGrounded && velocity.y < 0){

            velocity.y = -2.0f;
            
        }

        // if(isGrounded && jumpAction.ReadValue<Button>()){
            
            

        // }
        
        controller.Move(velocity*Time.deltaTime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
