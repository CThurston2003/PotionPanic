// /// Author: Caleb Thurston (CAT)
// /// Description: Player Movement code for Potion Panic (PP)
// /// Script Language: C#
// /// Date Created: Sept 21, 2024



// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.InputSystem;


// //Not Extremely important bugs to eventually fix:
// //
// //-When player is falling, they fall extremely slow (Only not
// //sure if ill fix this because im not sure the player will jump)


// //IMPORTANT bugs to fix
// //
// //Moving player with WASD moves them only in the cardinal direction, not relative direction


// public class PlayerMovement : MonoBehaviour
// {

//     //---------Variables-----------------
//     //Player Movement variables
//     public float moveFactor; //Factor to multiple player movement by
//     public Rigidbody playerBody; //Reference to players body
//     Vector2 playerMove; //Vector to store the players movement
//     private PlayerInput playerInput; //referencing the player input
//     private InputAction moveAction; //Storing the move actions to be referenced in this script easier 
    
//     //Player Viewpoint Variables
//     public Camera playerView; //Providing reference to player camera
//     public float horiSpeed = 1.0f; //Default horizontal speed of camera
//     public float vertSpeed = 1.0f; //Default verticle speed of camera
//     public float hori = 0; //Horizontal rotation (AKA Yaw)
//     public float vert = 0; //Vert rotation 

//     //awake function
//     private void awake(){

//         //Tying the specific player input script, to this script
//         playerInput = GetComponent<PlayerInput>();

//         //Storing move actions in moveActions
//         moveAction = playerInput.actions["Move"];

//     }


// //move function
//     public void onMove(){


//         //Debug.Log(context);
        
//         //Hopefully code that handles the basic movement of the player
//         //playerMove = context.ReadValue<Vector2>(); 


//     }



//     // Start is called before the first frame update
//     void Start()
//     {
        
//         Cursor.lockState = CursorLockMode.Locked;
//         Cursor.visible = false;

//     }

//     //Fixed Update command (Things not wanted to be tied to framerate should be put here)
//     void FixedUpdate(){

        

        

        

//         //playerBody.velocity = playerMove;
//         playerBody.MovePosition(playerMove);
        

        


//         hori += horiSpeed * Input.GetAxis("Mouse X");
//         vert -= vertSpeed * Input.GetAxis("Mouse Y");

//         transform.eulerAngles = new Vector3(vert, hori, 0.0f);

//     }

//     // Update is called once per frame
//     void Update()
//     {
        
        
       

//     }
// }
