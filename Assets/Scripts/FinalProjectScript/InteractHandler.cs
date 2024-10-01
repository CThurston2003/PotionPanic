using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractHandler : MonoBehaviour
{
    //-----------------Variables-----------------
    public Transform playerCamera; //Transform variable to store the camera's transform component
    public LayerMask interactables; //Creating a layer mask to assign all interactables too
    public Transform playerBody; //Transform variable to store the player's Transform component

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 upDown = new Vector3(0f, playerCamera.localRotation.x, 0f);

        Debug.DrawLine(playerCamera.position, playerBody.forward - upDown);

    }
}
