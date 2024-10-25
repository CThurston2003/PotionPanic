using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    
    private TestingScript2 test = new TestingScript2();
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(test.TheTest);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
