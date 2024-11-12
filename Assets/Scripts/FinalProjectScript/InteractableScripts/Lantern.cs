//Name: Caleb Thurston
//Description: 
//Script to deal with lantern functionality that will act as the primary light source for
//the player
//Language: C#
//Part of Project: Potion Panic

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Required Components
[RequireComponent(typeof(MultiTag))] //Required Multitag
[RequireComponent(typeof(Rigidbody))] //Required Rigidbody

public class Lantern : MonoBehaviour, IInteractable
{
    //-----------------------Variables Section---------------------

    //Creating a reference to the actual light of the lanter
    [SerializeField] private GameObject lightGlow;

    //Bool to keep track of the lights state
    private bool lightOn = true;
    
    
    // Start is called before the first frame update
    void Start()
    {
        


    }

    //Implementing abstract method Interact from the Interactable interface
    public void Interact(){
        lightOn = !lightOn;
        lightGlow.SetActive(lightOn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
