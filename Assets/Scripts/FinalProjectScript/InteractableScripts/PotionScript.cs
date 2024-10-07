using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour, IInteractable, IPickUp
{
    
    //------------------------Variables Section-------------------------

    // //Creating a reference to the playerCamera object
    // [SerializeField] private GameObject playerCamera;
    
    // //Creating a reference to the Interaction Handler script
    // InteractionHandler interactionHandler;

    //Reference to the holdPosition transform to determine where an object is held when the player interacts with it
    [SerializeField] Transform holdPosition;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        // //Tying reference to Interaction Handler to the actual script on the playerCamera
        // interactionHandler = playerCamera.GetComponent<InteractionHandler>();

    }


    //Implementing abstract method from IInteractable interface
    public void Interact(){


    }

    public void PickUp(){

        Debug.Log("Trying to Pick Me Up!");

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
