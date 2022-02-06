using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMinionScript : MonoBehaviour
{
    [SerializeField]
    private int _Speed;

    [SerializeField]
    private GameObject _LaserPrefab;

    [SerializeField]
    public float _fireRate = 20f;
    [SerializeField]
    private float _canFire = 0.0f;

    void Start()
    {
        
    }
    private void Update()
    {

        if (transform.position.y < -6f)
        {
            Destroy(this.gameObject);

        }
    }
    private void FixedUpdate()
    {
        transform.Translate(new Vector3(0, -1, 0) * _Speed * Time.deltaTime);
    }
    private void EnemyShooting()
    {
        if (Time.time > _canFire)
        {
            _canFire = _fireRate + Time.time;
            Instantiate(_LaserPrefab, transform.position + new Vector3(1, 0f, 0), Quaternion.identity);

        }
    }
}
