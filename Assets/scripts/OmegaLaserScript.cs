using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmegaLaserScript : MonoBehaviour
{
    [SerializeField]
    private float _LaserSpeed = 8f;

    // Start is called before the first frame update
    void Start()
    {
      
       
    }
    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.down * _LaserSpeed * Time.deltaTime);

        Destroy(gameObject, 1f);
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "DarkOrb")
        {

           
            Destroy(col.gameObject);

        }
        
    }
}