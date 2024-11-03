//Name: Caleb Thurston
//Description: 
//Script used as a base for ingredients to base off of
//Language: C#
//Part of Project: Potion Panic

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientBase : MonoBehaviour, IInteractable, IIngredient
{
    //------------------Variable Section--------------

    
    //Abstract Methods
    
    //Interact Method
    public void Interact(){

        Debug.Log(this.GetComponent<MultiTag>().GetAtIndex(0));

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
