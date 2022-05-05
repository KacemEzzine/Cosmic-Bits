using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : BaseEnemyScript
{

    //public float EnemyHp = 500f;
    //
    //
    //[SerializeField]
    //private float _Speed = 7f; 
    //
    //[SerializeField]
    //private GameObject _LaserPrefab;
    //
    //[SerializeField]
    //public float _fireRate = 20f;
    //[SerializeField]
    //private float _canFire = 0.0f;
    //public Transform FirePoint;

    //public static EnemyScript Ref;
    //private void Awake()
    //{
    //
    //    if (Ref == null)
    //    {
    //        Ref = this;
    //
    //    }
    //    else
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
    public GameObject UnLaserPrefab1;
    public int BulletStep = 0;



    void Start()
    {
        _LaserPrefab.transform.up = FirePoint.transform.up;
        PlayerMeshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        BlinkTimer -= Time.deltaTime;
        float lerp = Mathf.Clamp01(BlinkTimer / BlinkDuration);
        float Intensity = (lerp * BlinkIntensity) ;
        PlayerMeshRenderer.material.color = new Color(191, 0, 5) * Intensity;

        if (EnemyHp <= 0)
        {
            FindObjectOfType<SoundManagerScript>().Play("EnemyDeath");
            Destroy(this.gameObject);
            
        }
        
    }
    private void FixedUpdate()
    {
        EnemyShooting();
        EnemyMovement();
        
    }
    public override void EnemyShooting()
    {
        if (BulletStep < 1)
        {

            if (Time.time > _canFire)
            {
                _canFire = _fireRate + Time.time;
                Instantiate(_LaserPrefab, FirePoint.position + new Vector3(0, 0, 0), FirePoint.rotation);
                BulletStep++;
            }
        }
        else
        {
            if (Time.time > _canFire)
            {
                _canFire = _fireRate + Time.time;

                Instantiate(UnLaserPrefab1, FirePoint.position + new Vector3(0, 0, 0), FirePoint.rotation);
                BulletStep = 0;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lazer")
        {
            FindObjectOfType<SoundManagerScript>().Play("HitSFX");
            if ( BlinkTimer <= 0f)
            {
                
            }
            EnemyHp -= PlayerScript.Ref.DamageMultiplier;

            BlinkTimer = BlinkDuration;
            

        }
    }
    public override void EnemyMovement()
    {
        transform.Translate(new Vector3(1, 0, 0) * _Speed * Time.deltaTime);
        if (transform.position.x >= 20f)
        {
            _Speed = -7f;
        }
        else if (transform.position.x <= -20f)
        {
            _Speed = 7f;
        }
    }

}
