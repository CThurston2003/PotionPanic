using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoilFlask : MonoBehaviour, IInteractable, IMiniObject
{
    //-------------Variables Section------------------



    //Defining abstract methods inherited from interface
    
    //From IInteractable
    public void Interact(){



    }

    //From IMiniObject
    public void MiniInteract(){

        if(Input.GetKey("left")){

            Debug.Log("Testing if left works");
            this.transform.localRotation = Quaternion.Euler(0,0,-1);

        }else if(Input.GetKey("right")){

            Debug.Log("Testing if right works");
            this.transform.localRotation = Quaternion.Euler(0,0,1);

        }

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
