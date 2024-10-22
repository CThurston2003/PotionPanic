//in class script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMove : MonoBehaviour
{
    //----------------Variables section-----------------
    
    private Transform rocketTransform;
    private Rigidbody rocketBody;
    [SerializeField] private int thrust = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
        rocketTransform = this.GetComponent<Transform>();
        rocketBody = this.GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        
        rocketBody.AddRelativeForce(Vector3.up * thrust);

    }
}
