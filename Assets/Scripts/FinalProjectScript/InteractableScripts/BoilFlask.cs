//Name: Caleb Thurston
//Description: 
//Script to deal with the boiling minigame
//Language: C#
//Part of Project: Potion Panic

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    //Variable to store the players score in
    private int playerScore = 0;

    //Reference to the text part of the Canvas that displays the player's boil score
    [SerializeField] private TMP_Text scoreText;

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

    //MiniRun abstract method
    public void MiniRun(){

        //deciding a new trigger to turn on based on if theres not any triggers on currently
        if(triggerOn == false){

            //Randomly deciding between the 5 triggers
            randTrigger = Random.Range(1,6);
            triggerOn = true;

            //Switch case based on the output of randTrigger
            switch(randTrigger){

            case 1:
            currentTrigger = trigger1;
            currentTrigger.SetActive(true);
            StartCoroutine(triggerLife());
            break;

            case 2:
            currentTrigger = trigger2;
            currentTrigger.SetActive(true);
            StartCoroutine(triggerLife());
            break;

            case 3:
            currentTrigger = trigger3;
            currentTrigger.SetActive(true);
            StartCoroutine(triggerLife());
            break;

            case 4:
            currentTrigger = trigger4;
            currentTrigger.SetActive(true);
            StartCoroutine(triggerLife());
            break;

            case 5:
            currentTrigger = trigger5;
            currentTrigger.SetActive(true);
            StartCoroutine(triggerLife());
            break;
            }
        }

        //instantiating a ray to shoot from the fire
        ray = new Ray(fire.transform.position,fire.transform.up);
        
        //Checking if the player is holding the left or right arrow and if they are, 
        //it rotates the flask that direction
        if(Input.GetKey("left")){
            flaskRotation += 2;
        }else if(Input.GetKey("right")){
            flaskRotation -= 2;
        }
        this.transform.localRotation = Quaternion.Euler(this.transform.localRotation.x,this.transform.localRotation.y,flaskRotation);
    
        //Incrementing the score (Will look at this again later, placeholder to show functionality)
        if(Physics.Raycast(ray, out RaycastHit hit, 10, triggerLayer)){
            playerScore += 1;
            string score = playerScore.ToString();
            scoreText.text = score;
        }

    }

    //creating a Coroutine for the lifespan of the trigger
    IEnumerator triggerLife(){
        yield return new WaitForSeconds(triggerTimer);
        currentTrigger.SetActive(false);
        triggerOn = false;
    }
}
