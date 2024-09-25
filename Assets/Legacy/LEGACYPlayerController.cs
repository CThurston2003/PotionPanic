using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{


    //---------Variables----------
    private PlayerInput playerInput; //creating a variable for the player input object
    //private InputAction moveAction; //Creating an InputAction object to reference movements from the player
    private InputAction lookAction; //Creating an InputAction object to reference the players view
    private Rigidbody rigidBody; //Creating a rigidBody opject to reference players rigidbody
    //public float moveFactor; //The factor that the players movement is multiplied by
    private float yaw = 0.0f; //Horizontal rotation of players vision
    private float pitch = 0.0f; //Vertical rotation of players vision
    public float yawSpeed = 1.0f; //Speed modifier for yaw
    public float pitchSpeed = 1.0f; //Speed modifier for pitch
    public Transform playerBody; //Reference to the transform of the player body
    public Transform playerHead; //Reference to transform of player head
    public Rigidbody playerRigidbody;

    private float headRigidBodyX;
    private float bodyRigidBodyX;
   
    private void Awake(){

        //Tying the player input object to the script through this reference
        playerInput = GetComponent<PlayerInput>();

        //Referencing the look actions and tying it to the script
        lookAction = playerInput.actions["Look"];

        //Referencing the players rigidBody
        rigidBody = GetComponent<Rigidbody>();

        headRigidBodyX = rigidBody.rotation.x;
        bodyRigidBodyX = playerRigidbody.rotation.x;

    }
    
    // Start is called before the first frame update
    void Start()
    {

        //Locking cursor to screen and making the cursor invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    
    //Fixed Update function
    void FixedUpdate(){

        //Code segment for controlling player's first person view
        yaw += yawSpeed * lookAction.ReadValue<Vector2>().x * Time.deltaTime;
        pitch -= pitchSpeed * lookAction.ReadValue<Vector2>().y * Time.deltaTime;

        //Using a transform object to determine where the player is looking
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        
        //Setting a clamp so the user's view cant go past 90 (Note, I think Pitch and Yaw are backwards??)
        pitch = Mathf.Clamp(pitch, -90, 90);

        //Creating a vector to change the offset of the players head position
        //Setting the position of the player head to follow the player body
        Vector3 offSet = new Vector3(0f,0.5f,0f);
        playerHead.position = playerBody.position + offSet;
        //playerBody.rotation = playerHead.rotation.x;
        bodyRigidBodyX = headRigidBodyX;
        //Debug.Log(playerHead.rotation);



        


    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
