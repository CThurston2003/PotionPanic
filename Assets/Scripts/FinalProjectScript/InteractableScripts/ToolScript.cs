//Name: Caleb Thurston
//Description: 
//Script to deal with the cooking pot that the player will use
//Language: C#
//Part of Project: Potion Panic

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolScript : MonoBehaviour, IInteractable
{
    
    //------------------Variables Section------------------------

    //Reference to the gameobject that is the minigame
    [SerializeField] private GameObject miniGame;

    //Reference to a dummy game object to instantiate from
    [SerializeField] private GameObject dummyGame;

    //Variable to store whether the minigame is active or not
    private bool gameActive = false;

    //Variable to decide how much time the player has to do a minigame in seconds
    private int timeLimit = 30;

    //Variable to store miniGame position
    Vector3 gamePosition;

    //Variable to store miniGame rotation
    Quaternion gameRotation;

    //Ray variable for checking if the minigame is active above the tool
    private Ray ray;

    //Variable for the layerMask for the ray
    [SerializeField] private LayerMask interactables;

    
    //Creating a coroutine that will close the minigame if the player runs out of time
    IEnumerator gameTime(){

        yield return new WaitForSeconds(timeLimit);
        gameActive = false;
        Destroy(miniGame);
        miniGame = Instantiate(dummyGame, gamePosition, gameRotation);
        miniGame.SetActive(gameActive);
    }
    


    public void Interact(){

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
                
                    //Running the MiniRun command from the object if it does
                    miniObj.MiniRun();

                }
            }
        }
    }
}
