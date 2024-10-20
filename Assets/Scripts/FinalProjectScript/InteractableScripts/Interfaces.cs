//Name: Caleb Thurston
//Description: 
//Script to keep track of all the interfaces being used in the project
//Language: C#
//Part of Project: Potion Panic

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 //Creating an interactable interface that all interactable objects will inherit from
public interface IInteractable{

    //Abstract methods
    public void Interact();

}

//Interface for minigame objects to inherit from
public interface IMiniObject{

    //abstract methods
    // public void MiniInteract();

    public void MiniStart();

    public void MiniRun();

}


//Interface for ingredients to inherit from
public interface IIngredient{

    //Abstract Methods
    public void IngredientUse();

}

