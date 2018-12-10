using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float zAxis;

    void Start()
    {

    }


    void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down);
        }
        else if(Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up);
        }
        
    }
}
