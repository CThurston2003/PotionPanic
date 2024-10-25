//Name: Caleb Thurston
//Description: Script to deal with a specific instance of an interactable object
//Language: C#
//Part of Project: Potion Panic

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactee : MonoBehaviour, IInteractable
{

    //--------------------------Variables Section--------------------------
    
    // //Storing red green and blue value
    // [SerializeField] private float _red = 0;
    // [SerializeField] private float _green = 0;
    // [SerializeField] private float _blue = 0;

    //Creating Properties for red, green, and blue
    public float Red{get; set;}
    public float Green{get; set;}
    public float Blue{get; set;}


    //start method
    void Start(){

        

    }
    
    public void Interact(){

        Debug.Log("Color Change!");
        Red = Random.Range(0f,1f);
        Green = Random.Range(0f,0f);
        Blue = Random.Range(0f,1f);

        this.GetComponent<Renderer>().material.color = new Color(Red,Green,Blue);


    }

    
    
}
