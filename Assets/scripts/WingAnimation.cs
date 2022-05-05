using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingAnimation : MonoBehaviour
{
    private Vector3 OriginalPos;
    private Vector3 NewPos;
    private float t=0.3f;
    private float elapsedTime;
    float percentageComplete;
    private void Awake()
    {
        OriginalPos = transform.localPosition;
        NewPos = transform.localPosition + new Vector3(transform.localPosition.x *0.4f,0,0);
    }
    void Start()
    {
        transform.localPosition = NewPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponentInParent<PlayerScript>().IsShooting == true)
        {
            transform.localPosition = NewPos;
             
            elapsedTime = 0f;
        }

    if (gameObject.GetComponentInParent<PlayerScript>().IsShooting == false)
    {
            elapsedTime += Time.deltaTime;
            percentageComplete = elapsedTime / t;
            transform.localPosition = Vector3.Lerp(NewPos, OriginalPos, percentageComplete);
        }
    }
}
