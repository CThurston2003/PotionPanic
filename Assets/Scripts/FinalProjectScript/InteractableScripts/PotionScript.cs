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

    //Reference to the holdPosition transform to determine where an object is held when the player interacts with it
    [SerializeField] Transform holdPosition;


    // Start is called before the first frame update
    void Start()
    {
        

    }


    //Implementing abstract method from IInteractable interface
    public void Interact(){


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
