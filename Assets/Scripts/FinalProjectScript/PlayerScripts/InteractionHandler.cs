//Name: Caleb Thurston
//Description: 
//Script to deal with handling a player looking at an interactable object, and the basics of how it should interact
//As well as dealing with picking up objects that are able to be
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

public class InteractionHandler : MonoBehaviour
{
    //-------------------------Variables Section---------------------------
    
    //Creating a layer mask for all the interactables to exist on
    [SerializeField] private LayerMask interactables;

    //Creating a layer mask for all the pickups to exist on
    [SerializeField] private LayerMask pickUps;
    
    //Creating a reference to the player's camera to use as the raycast starting point
    [SerializeField] private Transform playerCamera;

    //Creating a reach variable to define how far away a player can "reach" an interactable
    [SerializeField] private float reach = 10f;

    //Reference to player character controller
    [SerializeField] private CharacterController characterController;

    //Ray variable to store the raycast in
    private Ray ray;

    //Reference to holdPosition's transform
    [SerializeField] Transform holdPosition;

    //Reference to hold position game object
    [SerializeField] private GameObject holdPosObj;

    //bool for keeping track if player is holding something
    private bool isHolding = false;


    
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
        if (Input.GetKeyDown("f")){

            //Sending a ray out from where the players looking to in front of them
            ray = new Ray(playerCamera.position,playerCamera.forward);

            //Checking if the raycast hits an object on the interactables layer, within "reach" distance
            //And if it finds an interactable it will trigger the interact method on it, inherited from the IInteractable interface on it
            if (Physics.Raycast(ray, out RaycastHit hit, reach, interactables)){
                
                //If case for interacting with an Interactable Only
                if(hit.collider.gameObject.TryGetComponent(out IInteractable interactionObj)){

                    interactionObj.Interact();

                }
            }
        }
    }

    // //Function to handle interacting with minigames
    // public void miniGameInteract(){

    //     //If player is left clicking on the miniGame canvas
    //     if(Input.GetMouseButtonDown(0)){

    //         //Sending a ray out from where the players looking, to whats in front of them
    //         ray = new Ray(playerCamera.position,playerCamera.forward);

    //         //Checking if the GraphicsRaycaster hits a part of the canvas
    //         if(Physics.Raycast(ray, out RaycastHit hit, reach, interactables, QueryTriggerInteraction.Collide)){

    //             if(hit.collider.isTrigger){

    //                 Debug.Log("Looking at trigger");


    //             }

    //         }

    //     }


    // }


    //Function to pickup and hold an item in front of the player
    public void pickUp(){

        //Sending a ray out from where the players looking to in front of them
        ray = new Ray(playerCamera.position,playerCamera.forward);
        
        if (Physics.Raycast(ray, out RaycastHit hit, reach, pickUps)){

            //If case for interacting with a pickup
            if(hit.collider.gameObject.TryGetComponent(out IInteractable pickUp) &&
            hit.collider.gameObject.TryGetComponent(out Transform pickUpObj)){

                //Checking if mouse is down and player is not currently holding something
                //Picking up the item if thats the case
                if(Input.GetMouseButtonDown(0) && isHolding == false){

                    pickUpObj.position = holdPosition.position;
                    pickUpObj.SetParent(holdPosition);
                    pickUpObj.transform.localRotation = new Quaternion(0,180,0,0);
                    hit.collider.gameObject.TryGetComponent(out Rigidbody rb);
                    rb.isKinematic = true;

                    isHolding = true;

                }
            }
        }

        //Checking if the holdPosition has an object as a child (its 1 because theres a sphere for easy positioning in scene view)
        if(holdPosition.childCount > 1){

            //Assigning the gameObject thats currently being held to heldObj
            GameObject heldObj = holdPosObj.transform.GetChild(1).gameObject;
            
            //Checking if player is clicking right click and already holding an item
            //And dropping the item if that is true
            if(Input.GetMouseButtonDown(1) && isHolding == true){

                heldObj.transform.SetParent(null);
                heldObj.GetComponent<Rigidbody>().isKinematic = false;
                heldObj.GetComponent<Rigidbody>().AddForce(heldObj.transform.forward * 2,ForceMode.Impulse);
                isHolding = false;

            }


            //Checking if player is clicking F and already holding an item
            //to interact with it
            
            if (!(Physics.Raycast(ray, out RaycastHit hit2, reach, interactables))){

                if(Input.GetKeyDown("f")){

                //Calling the interact function
                heldObj.TryGetComponent(out IInteractable intObj);
                intObj.Interact();

                }

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

        //Calling the pickup function
        pickUp();
        

    }


    void LateUpdate(){

    }

}
 