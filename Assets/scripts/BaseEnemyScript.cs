using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemyScript : MonoBehaviour
{
    public float EnemyHp = 500f;


    
    public float _Speed = 7f;

   
    public GameObject _LaserPrefab;

    
    public float _fireRate = 20f;
    
    public float _canFire = 0.0f;
    public Transform FirePoint;
    public MeshRenderer PlayerMeshRenderer;
    public float BlinkIntensity;
    public float BlinkDuration;
    public float BlinkTimer;

    //public static EnemyScript Ref;


    // Update is called once per frame

    public abstract void EnemyShooting();


    public abstract void EnemyMovement();
   
}
