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
    [SerializeField] private float _reach = 10f;
    //Creating a property for "_reach"
    public float Reach{
        get{
            return _reach;
        }
        set{
            _reach = value;
        }
    } 

    //Creating a variable for the throw power, when a player drops an item
    [SerializeField] private float _throw = 2;
    //Creating a property for "_throw"
    public float Throw{
        get{
            return _throw;
        }
        set{
            _throw = value;
        }
    }

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


    //Function to deal with sending a ray to check if a player is trying to interact with an interactable object
    public void interactCheck(){


        //Decided to use the old input system for the button for object interaction, because the new input system was causing issues
        //with triggering 3 times (because each call is broken up into 3 parts, but it ends up triggering an interaction 3 times each time)
        if (Input.GetKeyDown("f")){

            //Sending a ray out from where the players looking to in front of them
            ray = new Ray(playerCamera.position,playerCamera.forward);

            //Checking if the raycast hits an object on the interactables layer, within "reach" distance
            //And if it finds an interactable it will trigger the interact method on it, inherited from the IInteractable interface on it
            if (Physics.Raycast(ray, out RaycastHit hit, Reach, interactables)){
                
                //If case for interacting with an Interactable Only
                if(hit.collider.gameObject.TryGetComponent(out MultiTag InteractTag) && InteractTag.HasTags("Interactable")){
                    
                    //Checking if the interactable is specifically a tool for alchemy, and if not, just interacting with it
                    //Also making sure that if the player has an ingredient and interacts with it, it treats it accordingly
                    if(InteractTag.HasTags("Tool") && holdPosition.childCount > 1){
                        //Checking if the object that the player is holding, is an ingredient
                        if(holdPosObj.transform.GetChild(1).gameObject.TryGetComponent<MultiTag>(out MultiTag tag) && tag.HasTags("Ingredient")){
                            Debug.Log("Testingggg");
                            hit.collider.gameObject.GetComponent<IInteractableTool>().InteractTool(holdPosObj);
                            Destroy(holdPosObj.transform.GetChild(1).gameObject);
                            isHolding = false;
                        }
                        else{
                            hit.collider.gameObject.GetComponent<IInteractable>().Interact();
                        }
                    }else{
                        hit.collider.gameObject.GetComponent<IInteractable>().Interact();
                    }
                }
            }
        }
    }

    //Function to pickup and hold an item in front of the player
    public void pickUp(){

        //Sending a ray out from where the players looking to in front of them
        ray = new Ray(playerCamera.position,playerCamera.forward);
        
        if (Physics.Raycast(ray, out RaycastHit hit, Reach, pickUps)){

            GameObject pickUpObj = hit.collider.gameObject;

            //If case for interacting with a pickup
            if(pickUpObj.TryGetComponent(out MultiTag tagged) &&
            tagged.HasTags("Holdable")){

                //Checking if mouse is down and player is not currently holding something
                //Picking up the item if thats the case
                if(Input.GetMouseButtonDown(0) && isHolding == false){

                    pickUpObj.transform.position = holdPosition.position;
                    pickUpObj.transform.SetParent(holdPosition);
                    pickUpObj.transform.localRotation = new Quaternion(0,180,0,0);
                    pickUpObj.TryGetComponent(out Rigidbody rb);
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
                heldObj.GetComponent<Rigidbody>().AddForce(heldObj.transform.forward * Throw,ForceMode.Impulse);
                isHolding = false;

            }

            //Checking if player is clicking F and already holding an item
            //to interact with it
            
            if (!(Physics.Raycast(ray, out RaycastHit hit2, Reach, interactables))){

                if(Input.GetKeyDown("f")){

                    //Calling the interact function
                    heldObj.GetComponent<IInteractable>().Interact();
                    //intObj.Interact();

                }
            }
        }
    }


    //Fixed Update method
    void FixedUpdate()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

        //calling the interact check each update to check if the player is 
        interactCheck();

        //Calling the pickup function
        pickUp();

    }


    void LateUpdate()
    {

    }
}
 