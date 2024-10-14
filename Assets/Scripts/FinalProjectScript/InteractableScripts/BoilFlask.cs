//Name: Caleb Thurston
//Description: 
//Script to deal with the boiling minigame
//Language: C#
//Part of Project: Potion Panic

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoilFlask : MonoBehaviour, IInteractable, IMiniObject
{
    //-------------Variables Section------------------

    //Reference to the fire
    [SerializeField] private GameObject fire;
    
    
    //Variable to store the left & right rotation of the flask
    private int flaskRotation;

    //Reference to ray used in raycast
    private Ray ray;

    //Defining a layermask
    [SerializeField] private LayerMask triggerLayer;

    //Bool to keep track if a trigger is currently active
    private bool triggerOn = false;

    //variable to store how long between each new trigger
    private int triggerTimer = 5;

    //variable to store the random trigger number
    private int randTrigger;

    //variable to store current trigger
    private GameObject currentTrigger;

    //Hardcoded list of triggers on the boil flask
    [SerializeField] private GameObject trigger1;
    [SerializeField] private GameObject trigger2;
    [SerializeField] private GameObject trigger3;
    [SerializeField] private GameObject trigger4;
    [SerializeField] private GameObject trigger5;

    //List to store the triggers in


    //Defining abstract methods inherited from interface
    
    //From IInteractable, possible how the player puts the ingredients in the flask
    public void Interact(){



    }

    //From IMiniObject, this is where the actual minigame interaction works
    public void MiniInteract(){
        
        //deciding a new trigger to turn on based on if theres not any triggers on currently
        if(triggerOn == false){

            //Randomly deciding between the 5 triggers
            randTrigger = Random.Range(1,6);
            triggerOn = true;

        }

        //Switch case based on the output of randTrigger
        switch(randTrigger){

            case 1:
            currentTrigger = trigger1;
            currentTrigger.SetActive(true);

            break;

            case 2:

            break;

            case 3:

            break;

            case 4:

            break;

            case 5:

            break;

        }

        //instantiating a ray to shoot from the fire
        ray = new Ray(fire.transform.position,fire.transform.up);
        
        //Checking if the player is holding the left or right arrow and if they are, 
        //it rotates the flask that direction
        if(Input.GetKey("left")){
            flaskRotation += 1;
        }else if(Input.GetKey("right")){
            flaskRotation -= 1;
        }
        this.transform.localRotation = Quaternion.Euler(this.transform.localRotation.x,this.transform.localRotation.y,flaskRotation);
    
        if(Physics.Raycast(ray, out RaycastHit hit, 10, triggerLayer)){

            Debug.Log("Hitting a trigger");

        }





    }
    

    //creating a Coroutine for the lifespan of the trigger
    IEnumerator triggerLife(){

        yield return new WaitForSeconds(triggerTimer);


    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
