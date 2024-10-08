//Name: Caleb Thurston
//Description: Script to deal with handling a player looking at an interactable object, and the basics of how it should interact
//Language: C#
//Part of Project: Potion Panic

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


//Creating an interactable interface that all interactable objects will inherit from
public interface IInteractable{

    //Abstract methods
    public void Interact();

}

    

//Creating an interface for when an object can be picked up
public interface IPickUp{

    
    //Abstract methods
    public void PickUp();

}

public class InteractionHandler : MonoBehaviour
{
    //-------------------------Variables Section---------------------------
    
    //Creating a layer mask for all the interactables to exist on
    [SerializeField] private LayerMask interactables;
    
    //Creating a reference to the player's camera to use as the raycast starting point
    [SerializeField] private Transform playerCamera;

    //Creating a reach variable to define how far away a player can "reach" an interactable
    [SerializeField] private float reach = 10f;

    //Reference to player character controller
    [SerializeField] private CharacterController characterController;

    //Ray variable to store the raycast in
    private Ray ray;

    //Reference to holdPosition
    [SerializeField] Transform holdPosition;


    
    //Awake function
    void Awake(){


    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    //Function to deal with sending a ray to check if a player is trying to interact with an interactable object
    public void interactCheck(){


        //Decided to use the old input system for the button for object interaction, because the new input system was causing issues
        //with triggering 3 times (because each call is broken up into 3 parts, but it ends up triggering an interaction 3 times each time)
        if (Input.GetMouseButtonDown(0)){

            //Sending a ray out from where the players looking to in front of them
            ray = new Ray(playerCamera.position,playerCamera.forward);

            //Checking if the raycast hits an object on the interactables layer, within "reach" distance
            //And if it finds an interactable it will trigger the interact method on it, inherited from the IInteractable interface on it
            if (Physics.Raycast(ray, out RaycastHit hit, reach, interactables)){
                
                //If case for interacting with an Interactable Only
                if(hit.collider.gameObject.TryGetComponent(out IInteractable interactionObj) 
                && GameObject.FindWithTag("InteractOnly"))
                {

                    interactionObj.Interact();

                }
                
                
                

            }
           

        }

    }

    //Function to pickup and hold an item in front of the player
    public void pickUp(){

        if (Physics.Raycast(ray, out RaycastHit hit, reach, interactables)){

            //If case for interacting with a pickup
            if(hit.collider.gameObject.TryGetComponent(out IPickUp pickUp) &&
            GameObject.FindWithTag("PickUp") && hit.collider.gameObject.TryGetComponent(out Transform pickUpObj)){

                
                if(Input.GetMouseButtonDown(0)){

                    pickUpObj.position = holdPosition.position;
                    pickUpObj.parent = holdPosition;

                }else if(Input.GetMouseButtonUp(0)){

                    pickUpObj.SetParent(null);

                }
                
                

                
            
            }




        }

    }

    //Drop Function
    public void Drop(){

        if (Physics.Raycast(ray, out RaycastHit hit, reach, interactables)){

            //If case for interacting with a pickup
            if(hit.collider.gameObject.TryGetComponent(out IPickUp pickUp) &&
            GameObject.FindWithTag("PickUp") && hit.collider.gameObject.TryGetComponent(out Transform pickUpObj)){

                // pickUpObj.position = holdPosition.position;
                // pickUpObj.parent = holdPosition;

                pickUpObj.SetParent(null);
            
            }




        }

    }


    //Fixed Update method
    void FixedUpdate(){
              
        

    }

    // Update is called once per frame
    void Update()
    {

        //calling the interact check each update to check if the player is 
        interactCheck();

        pickUp();
       
        // if(Input.GetMouseButton(0)){

        //     pickUp();

        // }
        
        // if(Input.GetMouseButtonUp(0)){

        //     Drop();

        // }

        

    }


    void LateUpdate(){

    }

}
 