using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseShutter : MonoBehaviour, IInteractable
{
    //----------------------------Variables Section--------------------
    
    //To tell if shutter is open or closed
    private bool isOpen = true;

    //Reference to open and closed shutter model
    [SerializeField] private GameObject openShutter;
    [SerializeField] private GameObject closeShutter;
    
    
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    public void Interact(){
        isOpen = !isOpen;
        openShutter.SetActive(isOpen);
        closeShutter.SetActive(!isOpen);
        Debug.Log("Trying!");
    }

    // Update is called once per frame
    void Update()
    {


       
    }
}
