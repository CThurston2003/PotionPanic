/// Author: Caleb Thurston (CAT)
/// Description: Player Movement code for Potion Panic (PP)
/// Script Language: C#
/// Date Created: Sept 22, 2024


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementV2 : MonoBehaviour
{

    public float moveFactor; //Factor to multiple player movement by
    public Rigidbody playerBody; //Reference to players body
    public Transform playerOrientation; //Transform to keep track of players orientation
    Vector3 test;

    private float xMove;
    private float yMove;
    private float zMove;


    // Start is called before the first frame update
    void Start()
    {
        
        test = new Vector3(xMove, yMove, zMove);

    }

    
    void FixedUpdate(){

        if(Input.GetKey("w")){

            xMove = 1;

        }
        test = new Vector3(xMove, yMove, zMove);
        
        
        playerOrientation.Translate(test);
        


    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
