//Name: Caleb Thurston
//Description: 
//Script to deal with the cooking pot that the player will use
//Language: C#
//Part of Project: Potion Panic

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolScript : MonoBehaviour, IInteractable, IInteractableTool
{
    
    //------------------Variables Section------------------------

    //Reference to the gameobject that is the minigame
    [SerializeField] private GameObject miniGame;

    //Reference to a dummy game object to instantiate from
    [SerializeField] private GameObject dummyGame;

    //Variable to store whether the minigame is active or not
    private bool gameActive = false;

    //Variable to decide how much time the player has to do a minigame in seconds
    private int timeLimit = 10;

    //Variable to store miniGame position
    Vector3 gamePosition;

    //Variable to store miniGame rotation
    Quaternion gameRotation;

    //Ray variable for checking if the minigame is active above the tool
    private Ray ray;

    //Variable for the layerMask for the ray
    [SerializeField] private LayerMask interactables;

    //Variable to keep track of if the player clicked on the tool with an ingredient in hand
    private bool hasIngredient;

    
    //Creating a coroutine that will close the minigame if the player runs out of time
    IEnumerator gameTime(){

        yield return new WaitForSeconds(timeLimit);
        gameActive = false;
        Destroy(miniGame);
        miniGame = Instantiate(dummyGame, gamePosition, gameRotation);
        miniGame.SetActive(gameActive);
    }
    

    //Abstract method inherited from IInteractable
    //This interact method acts as showing the "Default" mode of the minigame, 
    //The Verson in which the player interacted with the tool without holding an ingredient
    public void Interact(){

        hasIngredient = false;
        
        //Code to toggle on or off the minigame when the player interacts with it
        gameActive = !gameActive;
        miniGame.SetActive(gameActive);

    }
    
    
    //Abstract method inherited from IInteractableTool
    //This InteractTool method acts as showing the "Active" version of the minigame
    //The version of the minigame that shows when the player interacts with it while actually holding an ingredient
    //and that starts the minigame
    public void InteractTool(bool ingredient){

        //Code to change the bool hasIngredient based on if the player interacted while holding an ingredient
        if(ingredient == true){
            hasIngredient = true;
        }

        //Code to toggle on or off the minigame when the player interacts with it
        gameActive = !gameActive;
        if(gameActive == true){
            StartCoroutine(gameTime());
        }
        miniGame.SetActive(gameActive);
    }


    
    
    // Start is called before the first frame update
    void Start()
    {

        //Setting the game position to be referenced later when creating a new instance of the minigame
        gamePosition = miniGame.transform.position;
        gameRotation = miniGame.transform.rotation;

       //Setting the game to be off at the start
       miniGame.SetActive(gameActive);
    }

    // Update is called once per frame
    void Update()
    {
        
        //--------Making A Raycast array of all the things above the tool and checking if one of them is a minigame--------
    
        //Only checking if the minigame is supposed to be active
        if(gameActive == true){

            //Making a raycast array and storing a RaycastAll in it
            RaycastHit[] hits;
            hits = Physics.RaycastAll(this.transform.position,this.transform.up, 10, interactables);

            //Iterating through the raycast array to check 
            for(int i = 0; i < hits.Length; i++){

                //Checking if the specific index in the Raycast array has the IMiniObject interface
                if(hits[i].collider.gameObject.TryGetComponent(out IMiniObject miniObj)){
                
                    //Running the MiniRun command from the object if it does, but only if the player has an ingredient
                    if(hasIngredient == true){
                        miniObj.MiniRun();
                    }
                }
            }
        }
    }
}
