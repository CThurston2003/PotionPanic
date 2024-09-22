/// Author: Caleb Thurston (CAT)
/// Description: Player Movement code for Potion Panic (PP)
/// Script Language: C#
/// Date Created: Sept 21, 2024



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;




public class PlayerMovement : MonoBehaviour
{

    //---------Variables-----------------
    public float moveFactor; //Factor to multiple player movement by
    public Rigidbody playerBody; //Reference to players body
    Vector3 playerMove; //Vector to store the players movement


//move function
public void onMove(InputAction.CallbackContext context){

    Debug.Log("Still working!");


    //Hopefully code that handles the basic movement of the player
    playerMove = context.ReadValue<Vector3>(); 
    //Debug.Log(playerMove);


}


    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    //Fixed Update command (Things not wanted to be tied to framerate should be put here)
    void FixedUpdate(){

        playerBody.transform.position = playerMove;
        //Debug.Log(playerBody.velocity.y);

    }

    // Update is called once per frame
    void Update()
    {
        
        
       

    }
}
