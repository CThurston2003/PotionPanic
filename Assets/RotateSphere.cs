//Caleb Thurston
//Description: Script for rotating sphere around cube
//Language: C#


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSphere : MonoBehaviour
{
    
    //Creating variable to store spheres rotate in
    private Transform spherePos;

    //Creating a variable to store the cube's transform that its looking at
    [SerializeField] private Transform cubePos;

    
    // Start is called before the first frame update
    void Start()
    {
        
        spherePos = this.GetComponent<Transform>();
        spherePos.position = new Vector3(cubePos.position.x + 5f,cubePos.position.y + 5f,cubePos.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        spherePos.LookAt(cubePos);
        spherePos.Translate(Vector3.right * 10 * Time.deltaTime);

    }
}
