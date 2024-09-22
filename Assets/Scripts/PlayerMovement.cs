/// Author: Caleb Thurston (CAT)
/// Description: Player Movement code for Potion Panic (PP)
/// Script Language: C#
/// Date Created: Sept 21, 2024



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


//Not Extremely important bugs to eventually fix:
//
//-When player is falling, they fall extremely slow (Only not
//sure if ill fix this because im not sure the player will jump)



public class PlayerMovement : MonoBehaviour
{

    //---------Variables-----------------
    //Player Movement variables
    public float moveFactor; //Factor to multiple player movement by
    public Rigidbody playerBody; //Reference to players body
    Vector3 playerMove; //Vector to store the players movement
    
    //Player Viewpoint Variables
    public Camera playerView; //Providing reference to player camera
    public float horiSpeed = 1.0f; //Default horizontal speed of camera
    public float vertSpeed = 1.0f; //Default verticle speed of camera
    public float hori = Input.GetAxisRaw("Horizontal"); //Horizontal rotation (AKA Yaw)
    public float vert = Input.GetAxisRaw("Vertical"); //Vert rotation 
    Vector2 playerViewpoint; //Vector 2 to store player viewpoint x and y
    Vector3 m_EulerAngleVelocity;

//move function
    public void onMove(InputAction.CallbackContext context){

        //Debug.Log("Still working!");


        //Hopefully code that handles the basic movement of the player
        playerMove = context.ReadValue<Vector3>(); 
        //Debug.Log(playerMove);


    }

    public void onLook(InputValue inputValue){


        //Storing players viewpoint in x and y in vector 2
        //playerViewpoint = context.ReadValue<Vector3>();

        //Testing to see if the onLook function is being called
        Debug.Log("IM LOOKING MA");
        Debug.Log(inputValue);

        //m_EulerAngleVelocity = context.ReadValue<Vector3>();

    }


    // Start is called before the first frame update
    void Start()
    {
        
        m_EulerAngleVelocity = new Vector3(0, 0, 0);

    }

    //Fixed Update command (Things not wanted to be tied to framerate should be put here)
    void FixedUpdate(){

        //m_EulerAngleVelocity = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

        Debug.Log(hori);

        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);

        playerBody.velocity = playerMove;
        playerBody.MoveRotation(playerBody.rotation * deltaRotation);

        //Debug.Log(playerBody.velocity.y);

    }

    // Update is called once per frame
    void Update()
    {
        
        
       

    }
}
