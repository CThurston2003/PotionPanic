//Name: Caleb Thurston
//Description: 
//Script used as a base for ingredients to base off of
//Language: C#
//Part of Project: Potion Panic

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Required Components
[RequireComponent(typeof(MultiTag))] //Required Multitag
[RequireComponent(typeof(Rigidbody))] //Required Rigidbody


public class IngredientBase : MonoBehaviour, IInteractable, IIngredient
{
    //------------------Variable Section--------------

    
    //Abstract Methods
    
    //Interact Method
    public void Interact(){

        //Testing the multitag system to see if the console actually outputs true because this object has the Holdable tag
        Debug.Log(this.GetComponent<MultiTag>().HasTags("Holdable"));

    }

    //IngredientUse Method
    public void IngredientUse(){

        

    }
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
