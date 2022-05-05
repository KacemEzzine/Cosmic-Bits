using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundPoint : MonoBehaviour
{
    public float RotationSpeed;
    public GameObject PivotPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(PivotPoint.transform.position, new Vector3(0, 0, 1), RotationSpeed * Time.deltaTime);
    }
}
