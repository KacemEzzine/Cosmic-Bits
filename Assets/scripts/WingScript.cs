using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(1.0f, 0.0f, 0.0f, Space.World);
    }
    public Transform target;


    
}
