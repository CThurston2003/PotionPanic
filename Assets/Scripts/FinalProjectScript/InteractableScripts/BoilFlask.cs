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

    //Reference to the tool that the flask is on top of
    [SerializeField] private GameObject boilTool;
    
    //Reference to the fire
    [SerializeField] private GameObject fire;
    
    //Variable to store the left & right rotation of the flask
    private int _flaskRotation;
    public int FlaskRotation{get; set;}

    //Reference to ray used in raycast
    private Ray ray;

    //Defining a layermask
    [SerializeField] private LayerMask triggerLayer;

    //Bool to keep track if a trigger is currently active
    private bool triggerOn = false;

    //variable to store how long between each new trigger
    private int _triggerTimer = 5;
    public int TriggerTimer{
        get{
            return _triggerTimer;
        }
        set{
            _triggerTimer = value;
        }
    }

    //variable to store the random trigger number
    private int _randTrigger;
    public int RandTrigger{get; set;}

    //variable to store current trigger
    private GameObject currentTrigger;

    //Variable to store the players score in
    private int _playerScore;
    public int PlayerScore{get; set;}


    //Reference to the text part of the Canvas that displays the player's boil score
    [SerializeField] private TMP_Text scoreText;

    //Hardcoded list of triggers on the boil flask
    [SerializeField] private GameObject trigger1;
    [SerializeField] private GameObject trigger2;
    [SerializeField] private GameObject trigger3;
    [SerializeField] private GameObject trigger4;
    [SerializeField] private GameObject trigger5;

    //Position for the resulting ingredient or object to be dropped at
    [SerializeField] private Transform outputPosition;

    //Blank potion to be instantiated based on the player reaching the needed score
    [SerializeField] private GameObject BlankPotion;

    //Bool to keep track if a result was spit out
    private bool gotResult = false;

    //Setting the Used Ingredient by checking the first tag of the tool the boil flask is attached too
    private string ingredient;
    
    //bool to determine if the first index was turned to the stored ingredient
    private bool changeIng = false;
    
    
    public void Start(){

        //Assigning the used ingredient
        ingredient = boilTool.GetComponent<MultiTag>().GetAtIndex(0);
        //delIngredient = false;



    }


    public void Update(){

        if(gotResult == true && changeIng == false){
            boilTool.GetComponent<MultiTag>().Rename(0, ingredient);
            changeIng = true;
        }

        if(changeIng == true){

            boilTool.GetComponent<MultiTag>().Rename(0, "Tool");
            changeIng = false;

        }

    }

    //Defining abstract methods inherited from interface
    
    //From IInteractable, possible how the player puts the ingredients in the flask
    public void Interact(){


    }

    //function to set potion (and later ingredients instead) attributes
    // public void SetAttributes(GameObject Potion, GameObject Ingredient){
        
    //     //String to store the name of the ingredient
    //     string ingredientName = Ingredient.GetComponent<MultiTag>().GetAtIndex(1);
    //     string potionType;

    //     //Switch case for assigning the potion attributes based 
    //     switch(ingredientName){

    //         case "Mint":
    //         potionType = "&01&";
    //         Potion.GetComponent<PotionScript>().PotionID = potionType;
    //         break;
            
    //         case "TreeLeaf":
    //         potionType = "&02&";
    //         Potion.GetComponent<PotionScript>().PotionID = potionType;
    //         break;

    //         case "Alcohol":
    //         potionType = "&03&";
    //         Potion.GetComponent<PotionScript>().PotionID = potionType;
    //         break;

    //         case "Water":
    //         potionType = "&04&";
    //         Potion.GetComponent<PotionScript>().PotionID = potionType;
    //         break;

    //         case "Clay":
    //         potionType = "&00&";
    //         Potion.GetComponent<PotionScript>().PotionID = potionType;
    //         break;

    //     }

        
        

    // }

    //MiniRun abstract method
    public void MiniRun(){

        //Debug.Log(delIngredient);
        
        //deciding a new trigger to turn on based on if theres not any triggers on currently
        if(triggerOn == false){

            //Randomly deciding between the 5 triggers
            RandTrigger = Random.Range(1,6);
            triggerOn = true;

            //Switch case based on the output of RandTrigger
            switch(RandTrigger){

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
            FlaskRotation += 2;
        }else if(Input.GetKey("right")){
            FlaskRotation -= 2;
        }
        this.transform.localRotation = Quaternion.Euler(this.transform.localRotation.x,this.transform.localRotation.y,FlaskRotation);
    
        //Incrementing the score (Will look at this again later, placeholder to show functionality)
        if(Physics.Raycast(ray, out RaycastHit hit, 10, triggerLayer)){
            PlayerScore += 1;
            string score = PlayerScore.ToString();
            scoreText.text = score;
        }

        //Creating a condition to spawn the required ingredient when the score reaches the specified threshold
        if(PlayerScore >= 100 && gotResult == false){

            Debug.Log("Spit out a potion!");
            gotResult = true;
            GameObject newPotion = Instantiate(BlankPotion);
            newPotion.transform.position = outputPosition.position;

            //Setting the Potion/Ingredient Attributes
            //SetAttributes(newPotion, Ingredient);

        }

    }

    //creating a Coroutine for the lifespan of the trigger
    IEnumerator triggerLife(){
        yield return new WaitForSeconds(TriggerTimer);
        currentTrigger.SetActive(false);
        triggerOn = false;
    }
}
