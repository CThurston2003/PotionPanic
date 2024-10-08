using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour, IInteractable, IPickUp
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

    public void PickUp(){


        Debug.Log("Trying to Pick Me Up!");
        transform.position = holdPosition.position;

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
