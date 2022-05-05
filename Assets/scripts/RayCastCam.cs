using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastCam : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void LateUpdate()
    {
     // if (Player.transform.position.x < -13 || Player.transform.position.x>13) { 
     // transform.position = new Vector3(transform.position.x, Player.transform.position.y, transform.position.z);
     // }
     // else
     // {
            transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z);
       // }
        
    }
}
