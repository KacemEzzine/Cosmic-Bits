using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryEnemyScript : BaseEnemyScript
{
    // Start is called before the first frame update
    public Transform FirePoint_2;
    public Transform FirePoint_3;
    public Transform FirePoint_4;
    public GameObject LaserPrefab2;
    public GameObject LaserPrefab3;
    public GameObject LaserPrefab4;
    public GameObject UnLaserPrefab1;
    public GameObject UnLaserPrefab2;
    public GameObject UnLaserPrefab3;
    public GameObject UnLaserPrefab4;
    public int BulletStep=0;
    private void Start()
    {
        _LaserPrefab.transform.up = FirePoint.transform.up;
        LaserPrefab2.transform.up = FirePoint_2.transform.up;
        LaserPrefab3.transform.up = FirePoint_3.transform.up;
        LaserPrefab4.transform.up = FirePoint_4.transform.up;
        UnLaserPrefab1.transform.up = FirePoint.transform.up;
        UnLaserPrefab2.transform.up = FirePoint_2.transform.up;
        UnLaserPrefab3.transform.up = FirePoint_3.transform.up;
        UnLaserPrefab4.transform.up = FirePoint_4.transform.up;
        PlayerMeshRenderer = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        BlinkTimer -= Time.deltaTime;
        float lerp = Mathf.Clamp01(BlinkTimer / BlinkDuration);
        float Intensity = (lerp * BlinkIntensity) ;
        PlayerMeshRenderer.material.color = new Color(191,0,5) * Intensity;

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
        if (BulletStep < 7)
        {
            if (Time.time > _canFire)
            {
                _canFire = _fireRate + Time.time;

                Instantiate(_LaserPrefab, FirePoint.position + new Vector3(0, 0, 0), FirePoint.rotation);
                Instantiate(LaserPrefab2, FirePoint_2.position + new Vector3(0, 0, 0), FirePoint_2.rotation);
                Instantiate(LaserPrefab3, FirePoint_3.position + new Vector3(0, 0, 0), FirePoint_3.rotation);
                Instantiate(LaserPrefab4, FirePoint_4.position + new Vector3(0, 0, 0), FirePoint_4.rotation);
                BulletStep++;
            }
        }
        else
        {
            if (Time.time > _canFire)
            {
                _canFire = _fireRate + Time.time;

                Instantiate(UnLaserPrefab1, FirePoint.position + new Vector3(0, 0, 0), FirePoint.rotation);
                Instantiate(UnLaserPrefab2, FirePoint_2.position + new Vector3(0, 0, 0), FirePoint_2.rotation);
                Instantiate(UnLaserPrefab3, FirePoint_3.position + new Vector3(0, 0, 0), FirePoint_3.rotation);
                Instantiate(UnLaserPrefab4, FirePoint_4.position + new Vector3(0, 0, 0), FirePoint_4.rotation);
                BulletStep = 0;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lazer")
        {
            FindObjectOfType<SoundManagerScript>().Play("HitSFX");
            if (BlinkTimer <= 0f)
            {
                
            }
            BlinkTimer = BlinkDuration;

            EnemyHp -= PlayerScript.Ref.DamageMultiplier;

            
            
        }
    }
    public override void EnemyMovement()
    {

    }
   

}
