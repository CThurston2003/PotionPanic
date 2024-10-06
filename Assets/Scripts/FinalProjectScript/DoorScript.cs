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
    private int count = 0;
    public void Interact(){
        
        if(count == 0){

            Debug.Log("Door is Opening");
            doorAnim.SetTrigger("Open");
            count += 1;

        }else if(count == 1){

            Debug.Log("Door is Closing");
            doorAnim.SetTrigger("Close");
            count = 0;

        }

    }

}
