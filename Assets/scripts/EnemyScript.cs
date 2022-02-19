using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    
    public float EnemyHp = 500f;
   

    [SerializeField]
    private float _Speed = 7f; 

    [SerializeField]
    private GameObject _LaserPrefab;
    
    [SerializeField]
    public float _fireRate = 20f;
    [SerializeField]
    private float _canFire = 0.0f;
    public Transform FirePoint;

    public static EnemyScript Ref;
    private void Awake()
    {

        if (Ref == null)
        {
            Ref = this;

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyShooting();
        if (transform.position.x >= 20f)
        {
            _Speed = -7f;
        }else if (transform.position.x <= -20f)
                {
            _Speed = 7f;
        }
        if (EnemyHp <= 0)
        {
            Destroy(this.gameObject);
            
        }
        
    }
    private void FixedUpdate()
    {
        transform.Translate (new Vector3(1,0, 0) * _Speed * Time.deltaTime);
    }
    private void EnemyShooting()
    {
        if (Time.time > _canFire)
        {
            _canFire = _fireRate + Time.time;
            Instantiate(_LaserPrefab, FirePoint.position + new Vector3(0, -1f, FirePoint.position.z), Quaternion.identity);
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lazer")
        {

            EnemyHp -= PlayerScript.Ref.DamageMultiplier;
        }
    }

}
