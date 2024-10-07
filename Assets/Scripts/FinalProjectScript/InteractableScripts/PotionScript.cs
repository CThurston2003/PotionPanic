using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour, IInteractable
{
    
    //Implementing abstract method from IInteractable interface
    public void Interact(){

        Debug.Log("You're poking me");

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
