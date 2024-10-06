using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactee : MonoBehaviour, IInteractable
{

    //--------------------------Variables Section--------------------------
    
    //Storing red green and blue value
    [SerializeField] private float red;
    [SerializeField] private float green;
    [SerializeField] private float blue;


    //start method
    void Start(){

        

    }
    
    public void Interact(){

        Debug.Log("Color Change!");
        red = Random.Range(0f,1f);
        green = Random.Range(0f,0f);
        blue = Random.Range(0f,1f);

        this.GetComponent<Renderer>().material.color = new Color(red,green,blue);


    }

    
    
}
