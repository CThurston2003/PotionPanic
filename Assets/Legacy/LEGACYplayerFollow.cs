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
    public float speed = 2f;
    
    //Awake function
    private void Awake(){

        //Tying the player input object to the script through this reference
        playerInput = GetComponent<PlayerInput>();
        
        //Referencing the movement actions and tying it to the script
        moveAction = playerInput.actions["Move"];

        //Referencing the look actions and tying it to the script
        lookAction = playerInput.actions["Look"];

        //Tying the player's body's rigidbody to this script
        rigidBody = GetComponent<Rigidbody>();


    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Fixed update function
    void FixedUpdate(){

        //Debug.Log(moveAction.ReadValue<Vector2>().x);

        // Vector3 movement = new Vector3(moveAction.ReadValue<Vector2>().x * Time.deltaTime,0f,moveAction.ReadValue<Vector2>().y * Time.deltaTime);
        // //rigidBody.velocity += movement;
        // rigidBody.velocity = transform.forward * 2 * Time.deltaTime;

        // Debug.Log(transform.forward);

        // Vector3 movement = new Vector3(moveAction.ReadValue<Vector2>().x * Time.deltaTime,0f,moveAction.ReadValue<Vector2>().y * Time.deltaTime);

        // rigidBody.velocity = movement * 100;
        // //Debug.Log(movement);


        // Vector3 Movement = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    
        // playerBody.transform.position += Movement * 5 * Time.deltaTime;
        // rigidBody.AddRelativeForce(Vector3.forward * 1, ForceMode.VelocityChange);

        float xMove = Input.GetAxis("Horizontal"); 	//d changes value to 1, a changes value to -1
	    float zMove = Input.GetAxis("Vertical"); // w key changes value to 1, s key changes value to -1

        transform.position = transform.position + new Vector3(xMove * speed * Time.deltaTime, 0, zMove * speed * Time.deltaTime);

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
