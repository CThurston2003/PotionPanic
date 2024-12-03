//Name: Caleb Thurston
//Description: Script to deal with the player's belt that acts like their in-world inventory
//Language: C#
//Part of Project: Potion Panic


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltScript : MonoBehaviour
{
    //-----------Variables Section---------------------

    //Reference to players body
    [SerializeField] private GameObject PlayerBody;

    //Reference to the players camera
    [SerializeField] private GameObject PlayerCamera;

    //Variable to keep track of the difference in the rotation of the belt vs the player
    private float RotationDiff; 


    
    
    
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    //Pivot Function to deal with the belt pivoting around the player
    void Pivot(){

        //Keeping the belts position around the player
        this.transform.position = PlayerBody.transform.position;

        // Debug.Log(PlayerBody.transform.localRotation.eulerAngles.y);
        // Debug.Log(this.transform.localRotation.eulerAngles.y);
        
        //Calculating the difference in the rotation of the belt from the player's view
        RotationDiff = PlayerBody.transform.localRotation.eulerAngles.y - this.transform.localRotation.eulerAngles.y; 
        //RotationDiff = Mathf.Round(RotationDiff);

        //Debug.Log(RotationDiff);

        //If Statement for if the RotationDiff is too high
        if(RotationDiff > 100){
            this.transform.Rotate(0.0f, PlayerBody.transform.localRotation.eulerAngles.y, 0.0f);
        }else if(RotationDiff < -100){
            this.transform.Rotate(0.0f, PlayerBody.transform.localRotation.eulerAngles.y, 0.0f);
        }

    }


    // Update is called once per frame
    void Update()
    {
        
        //Calling the Pivot function
        Pivot();

    }
}
