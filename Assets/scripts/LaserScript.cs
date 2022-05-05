using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
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
      
        transform.Translate(Vector3.up * _LaserSpeed * Time.deltaTime);

        Destroy(gameObject, 3.5f);
    }

     void OnTriggerEnter(Collider col)
    {
        
         if (col.gameObject.tag =="DarkOrb")
        {

            Destroy(this.gameObject);
            Destroy(col.gameObject);

        }
        if (col.gameObject.tag == "HasHP")
        {

            Destroy(this.gameObject);

        }
    }
}

