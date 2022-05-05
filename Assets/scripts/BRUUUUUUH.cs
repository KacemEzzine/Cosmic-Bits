using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BRUUUUUUH : MonoBehaviour
{
    
    public Vector3 hitPoint;
    public PlayerScript Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var plane = new Plane(Vector3.forward, transform.position);
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var distance = new float();
        if (plane.Raycast(ray, out distance) )
        {

            hitPoint = ray.GetPoint(distance);
        }
       
        
     
    }
}
