

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float HP = 1000f;
    [SerializeField]
    public float _speed = 7f ;
    public float DamageMultiplier = 50f;
    [SerializeField]
    private GameObject _LaserPrefab;
    private Vector3 PlayerPos ;
    [SerializeField]
    public float _fireRate = 0.5f;
    [SerializeField]
    private float _canFire = 0.0f;
    //[SerializeField]
   // private float _canDash = 0.0f;
    //[SerializeField]
    //private float _DashPower = 50f;
    public bool IsShooting;
    public bool InputFeedBack;
    public Animator ShipAnimator;
    public GameObject UI;


    Vector3 lookingPos;
    public Camera cam;

    public static PlayerScript Ref;

    private void Awake()
    {
        if(Ref == null)
        {
            Ref = this;

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //take the current position = new position (0, 0, 0)
       //transform.position = new Vector3 (0,  0, 0);
    }

    // Update is called once per frame
    void Update()
    {
     Playermovement();
        InputFeedBack = Input.GetKey(KeyCode.Mouse0);
        IsShooting = InputFeedBack;
        ShipAnimator.SetBool("IsShooting", IsShooting);
        //Dash();
        Shoot();

      Ray lookingRay = cam.ScreenPointToRay(Input.mousePosition);
      RaycastHit Hit;
     
      if(Physics.Raycast(lookingRay, out Hit,300f))
      {
         var lookingPos = Hit.point;
            
            lookingPos.z = transform.position.z;
            transform.up = lookingPos - transform.position;
           // transform.RotateAround(transform.position, transform.up, 90);
        }
     
      


        if (HP <= 0f)
        {
            UI.SetActive(true);
            Destroy(this.gameObject);
        }
            
    }
    

    private void Shoot()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time > _canFire)
        {
            _canFire = _fireRate + Time.time;
            Instantiate(_LaserPrefab, transform.position + new Vector3(0, 0 , transform.position.z), Quaternion.identity);

        }
    }


   void Playermovement ()
   {
       PlayerPos = transform.position ;
       float horizontalInput = Input.GetAxis("Horizontal");
       float verticalInput = Input.GetAxis("Vertical");

        transform.position = new Vector3(transform.position.x + horizontalInput * _speed * Time.deltaTime, transform.position.y + verticalInput * _speed * Time.deltaTime, transform.position.z);

   
        if (transform.position.x>=20f)
       {
           transform.position = new Vector3(20f, transform.position.y, transform.position.z);
       }
       else if (transform.position.x<=-20f)
       {
           transform.position = new Vector3(-20f, transform.position.y, transform.position.z);
       }
        if (transform.position.y <= -8f)
        {
            transform.position = new Vector3(transform.position.x, -8f, transform.position.z);
        }
    }
   private void OnTriggerEnter(Collider other)
   {
       if (other.gameObject.tag == "DarkOrb")
       {
           Destroy(other.gameObject);
           HP -= 50f;
       }
   }
  //void Dash()
  //{
  //    float horizontalInput = Input.GetAxis("Horizontal");
  //    float verticalInput = Input.GetAxis("Vertical");
  //    if (Input.GetKeyDown(KeyCode.Space)&& Time.time > _canDash)
  //    {
  //        _canDash = 0.5f + Time.time;
  //        transform.position = new Vector3(transform.position.x + horizontalInput * _DashPower * Time.deltaTime, transform.position.y + verticalInput * _DashPower * Time.deltaTime, 0 * Time.deltaTime);
  //        
  //    }
  //}
}
