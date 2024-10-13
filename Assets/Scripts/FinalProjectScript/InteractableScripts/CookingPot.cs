//Name: Caleb Thurston
//Description: 
//Script to deal with the cooking pot that the player will use
//Language: C#
//Part of Project: Potion Panic

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingPot : MonoBehaviour, IInteractable
{
    
    //------------------Variables Section------------------------

    //Reference to the gameobject that is the minigame
    [SerializeField] private GameObject miniGame;

    //Variable to store whether the minigame is active or not
    private bool gameActive = false;
    
    //Implementing Abstract method from the interactable interface
    public void Interact(){

        //Code to toggle on or off the minigame when the player interacts with it
        gameActive = !gameActive;
        Debug.Log("The player is tryna interact with the pot!");
        miniGame.SetActive(gameActive);

    }
    
    
    // Start is called before the first frame update
    void Start()
    {

       //Setting the game to be off at the start
       miniGame.SetActive(gameActive);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
