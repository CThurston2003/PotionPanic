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

public class InteractionHandler : MonoBehaviour
{
    //-------------------------Variables Section---------------------------
    
    //Creating a layer mask for all the interactables to exist on
    [SerializeField] private LayerMask interactables;
    
    //Creating a reference to the player's camera to use as the raycast starting point
    [SerializeField] private Transform playerCamera;

    //Creating a reach variable to define how far away a player can "reach" an interactable
    [SerializeField] private float reach = 10f;

    //Ray variable to store the raycast in
    private Ray ray;





    
    //Awake function
    void Awake(){


    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }



    void interactCheck(){

        if (Input.GetKeyDown("f")){

            ray = new Ray(playerCamera.position,playerCamera.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, reach, interactables)){

                if(hit.collider.gameObject.TryGetComponent(out IInteractable interactionObj)){

                    interactionObj.Interact();

                }

            }

           

        }

    }
    
    // Update is called once per frame
    void Update()
    {

        interactCheck();

    }
}
 