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
    //BlankPotion: "&00&";
    //HealthPotion: "&01&";
    //SpeedPotion: "&02&";
    //StrengthPotion: "&03&";
    //PoisonPotion: "&04&";


    //Personal notes and Ideas for this script
   

   


    //Reference to the holdPosition transform to determine where an object is held when the player interacts with it
    [SerializeField] Transform holdPosition;
    

    //Variables to store colors for potion liquids
    private Color32 BlankPotion = new Color32(255,255,255,0);
    private Color32 HealthPotion = new Color32(204,6,29,0);
    private Color32 StrengthPotion = new Color32(214,91,9,0);
    private Color32 SpeedPotion = new Color32(15,217,203,0);
    private Color32 PoisonPotion = new Color32(9,107,35,0);


    // Start is called before the first frame update
    void Start()
    {
        //Storing the transform of the potion liquid to be able to easily modify it
        Transform potionLiquid = this.transform.Find("Sphere");

        //Setting the potion color based on its ID at the start
        potionColor(potionLiquid);

    }


    //Function to assign potionColor on start
    public void potionColor(Transform potionLiquid){

        //Switch case to deal with the different type of potions
        switch(PotionID){

            case "&01&":
                potionLiquid.GetComponent<Renderer>().material.color = HealthPotion;
                break;

            case "&02&":
                potionLiquid.GetComponent<Renderer>().material.color = StrengthPotion;
                break;

            case "&03&":
                potionLiquid.GetComponent<Renderer>().material.color = SpeedPotion;
                break;

            case "&04&":
                potionLiquid.GetComponent<Renderer>().material.color = PoisonPotion;
                break;

            default: 
                potionLiquid.GetComponent<Renderer>().material.color = BlankPotion;
                break;
        }

    }
    
    
    
    //Implementing abstract method from IInteractable interface
    //Possibly have this function in the interact of the actual potion instance, not this script?
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
