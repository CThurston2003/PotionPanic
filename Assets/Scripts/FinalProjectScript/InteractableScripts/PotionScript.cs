//Name: Caleb Thurston
//Description: 
//Script in which all potions use dealing with their interactions
//Language: C#
//Part of Project: Potion Panic

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour, IInteractable
{
    
    //------------------------Variables Section-------------------------

    // Making an ID system to keep track of different potion types to be later then used in a switch case
    // Potentially I could port this over to a dictionary system but im not 100% sure how I'd do that yet. 

    // Blank potion Id will be just 00, so thats the default the potion will start as
    // Temporarily a SerializedField so I can mess with it in play mode

    [SerializeField] private string PotionID = "&00&"; 

    //Starter Potion IDs
    private string BlankPotion = "&00&";
    private string HealthPotion = "&01&";
    private string SpeedPotion = "&02&";
    private string StrengthPotion = "&03&";
    private string PoisonPotion = "&04&";


    //Reference to the holdPosition transform to determine where an object is held when the player interacts with it
    [SerializeField] Transform holdPosition;


    // Start is called before the first frame update
    void Start()
    {
        

    }


    //Implementing abstract method from IInteractable interface
    public void Interact(){

        //Switch case to deal with the different type of potions
        switch(PotionID){

            case "&01&":

                Debug.Log("Health Potion!");
                break;

            case "&02&":

                Debug.Log("Strength Potion!");
                break;

            case "&03&":

                Debug.Log("Speed Potion!");
                break;

            case "&04&":

                Debug.Log("Poison Potion!");
                break;

            default: 
                
                Debug.Log("Blank Potion!");
                break;



        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
