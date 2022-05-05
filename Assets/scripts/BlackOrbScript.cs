using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackOrbScript : MonoBehaviour
{
    [SerializeField]
    private float _LaserSpeed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.up * _LaserSpeed * Time.deltaTime);

        
        Destroy(this.gameObject,3.5f);

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Lazer")
        {
            FindObjectOfType<SoundManagerScript>().Play("BlackOrbCollision");
        }
    }



}
