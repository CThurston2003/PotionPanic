// Caleb Thurston
// Language: C#
// Description: Script for applying force to a sphere to knock over a wall
// of physics cubes




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereForce : MonoBehaviour
{
    //Making a variable to store the sphere's rigidbody
    private Rigidbody sphereBody;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        //Getting reference to sphere's rigidbody
        sphereBody = this.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
        //Adding force to the spheres rigidBody
        sphereBody.AddForce(transform.forward * 3, ForceMode.Impulse);

    }
}
