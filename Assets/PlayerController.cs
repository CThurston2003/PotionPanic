using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{


    //---------Variables----------
    private PlayerInput playerInput; //creating a variable for the player input object
    private InputAction moveAction; //Creating an InputAction object to reference movements from the player
    private Rigidbody rigidBody; //Creating a rigidBody opject to reference players rigidbody
    public float moveFactor; //The factor that the players movement is multiplied by
    public float yaw; //Horizontal rotation of players vision
    public float pitch; //Vertical rotation of players vision
    public float yawSpeed; //Speed modifier for yaw
    public float pitchSpeed; //Speed modifier for pitch

    private void Awake(){

        //Tying the player input object to the script through this reference
        playerInput = GetComponent<PlayerInput>();

        //Referencing the movement actions and tying it to the script
        moveAction = playerInput.actions["Move"];

        //Referencing the players rigidBody
        rigidBody = GetComponent<Rigidbody>();

    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    //Fixed Update function
    void FixedUpdate(){

        //Testing references
        // Vector3 test = new Vector3(20.0f,0.0f,0.0f);
        // rigidBody.AddForce(test);

        //Code segment for controlling player's first person view
        yaw += yawSpeed * moveAction.ReadValue<Vector2>().x;
        pitch -= pitchSpeed * moveAction.ReadValue<Vector2>().y;

        //Debug tests
        Debug.Log(pitch);

            //Using a transform object to determine where the player is looking
        transform.eulerAngles = new Vector3(yaw, pitch, 0.0f);

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
