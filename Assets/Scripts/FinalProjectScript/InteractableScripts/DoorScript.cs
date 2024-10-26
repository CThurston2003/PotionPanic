//Name: Caleb Thurston
//Description: Script to deal with the the door receiving a signal the player is interacting with it, and to open the door
//Language: C#
//Part of Project: Potion Panic


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour, IInteractable
{
    
    //Reference to door animator
    private Animator doorAnim;
    
    //Start method
    void Start(){

        //Setting reference to game objects animator
        doorAnim = GetComponent<Animator>();

    }
    
    //Defining the abstract methods from IInteractable interface
    private int _count = 0;
    //creating a property for count
    public int Count{
        get{
            return _count;
        }
        set{
            _count = value;
        }
    }

    public void Interact(){
        
        if(Count == 0){

            Debug.Log("Door is Opening");
            doorAnim.SetTrigger("Open");
            Count += 1;

        }else if(Count == 1){

            Debug.Log("Door is Closing");
            doorAnim.SetTrigger("Close");
            Count = 0;

        }

    }

}
