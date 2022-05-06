using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    public float HP = 1000f;
    [SerializeField]
    public float _speed = 7f ;
    private bool _Moving;
    public float DamageMultiplier = 50f;
    [SerializeField]
    private GameObject _LaserPrefab;
    private Vector3 PlayerPos ;
    [SerializeField]
    public float _fireRate = 0.5f;
    [SerializeField]
    private float _canFire = 0.0f;
    private float _canFireOmega = 0.0f;
    [SerializeField]
    public float _fireRateOmega = 0.5f;
    
    public bool IsShooting;
    public bool InputFeedBack;
    public Animator ShipAnimator;
    public GameObject UI;
    public Transform FirePoint;
    public GameObject OmegaLaserPrefab;
    public float MaxHightLimit = 0;


    

    


    
    
   
    
    public bool EventCameraOn;


    //--VERTUAL POINT FOR THE PLAYER TO AIM AT--
    public BRUUUUUUH BRUH;
    public static PlayerScript Ref;

    MeshRenderer PlayerMeshRenderer;
    List<MeshRenderer> renderers = new List<MeshRenderer>();
    MeshRenderer PlayerChildMeshRenderer;
    public float BlinkIntensity;
    public float BlinkDuration;
     float BlinkTimer;

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
    
    void Start()
    {
       
       PlayerMeshRenderer = GetComponent<MeshRenderer>();

        //--THIS IS HOW TO ACCESS AND PUT THEM IN A LIST AND GET THEIR THE MESHRENDERER IN EACH CHILD OF THIS GAME OBJECT--
        foreach (Transform child in transform)
        {
            MeshRenderer renderer = child.GetComponent<MeshRenderer>();

            if (renderer != null)
            {
                renderers.Add(renderer);
            }
        }
    }
    private void LateUpdate()
    {
        
        // transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
    }
    private void FixedUpdate()
    {

        

    }

    // Update is called once per frame
    void Update()
    {
     
        InputFeedBack = Input.GetKey(KeyCode.Mouse0);
        IsShooting = InputFeedBack;

        var CurrentX = transform.position.x;
        Playermovement();
        var lookingPos = BRUH.hitPoint;
        float dist = Vector3.Distance(lookingPos, transform.position);
        // Debug.DrawLine(cam.transform.position, lookingPos, Color.black);

     
        if (Mathf.Abs(dist) > 0.4f && (lookingPos.x != CurrentX))//&& transform.eulerAngles.x==0 )
        {
            transform.up = lookingPos - transform.position;
        }

        Shoot();


       


        //lookingPos.z = transform.position.z;


        //--THIS IS FOR MAKING THE PLAYER FLASH WHEN THEY GET HIT--
        BlinkTimer -= Time.deltaTime;
        float lerp = Mathf.Clamp01(BlinkTimer / BlinkDuration);
        float Intensity = (lerp * BlinkIntensity) + 0.4f;
        PlayerMeshRenderer.material.color = Color.white * Intensity;
        
        //--THIS IS HOW TO CHANGE THE MESHRENDERER IN EACH CHILD OF THIS GAME OBJECT--
        foreach (var renderer in renderers)
        {
            renderer.material.color = Color.white * Intensity;
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
            Instantiate(_LaserPrefab, FirePoint.position + new Vector3(0, 0 , 0), FirePoint.rotation);
            FindObjectOfType<SoundManagerScript>().Play("PlayerLaserSound");
            IsShooting = true;

        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && Time.time > _canFireOmega)
        {
            _canFireOmega = _fireRateOmega + Time.time;
            Instantiate(OmegaLaserPrefab, FirePoint.position + new Vector3(0, 0, 0), FirePoint.rotation * Quaternion.Euler(180f, -90f, 0f));
            FindObjectOfType<SoundManagerScript>().Play("PlayerOmegaLaserSound");
            IsShooting = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0)|| Input.GetKeyUp(KeyCode.Mouse1))
        {
            IsShooting = false;
        }
        
        


    }


   void Playermovement ()
   {
       PlayerPos = transform.position ;
       float horizontalInput = Input.GetAxis("Horizontal");
       float verticalInput = Input.GetAxis("Vertical");



        Vector3 MoveDir = new Vector3(horizontalInput, verticalInput,0);
        if (MoveDir.magnitude > 1)
        {
            MoveDir = MoveDir.normalized;
        }
        //transform.position= new Vector3(transform.position.x + horizontalInput * _speed * Time.deltaTime, transform.position.y + verticalInput * _speed * Time.deltaTime, transform.position.z);
      transform.position += MoveDir * _speed * Time.deltaTime;

   
        if (transform.position.x>=23f)
       {
           transform.position = new Vector3(23f, transform.position.y, transform.position.z);
       }
       else if (transform.position.x<=-23f)
       {
           transform.position = new Vector3(-23f, transform.position.y, transform.position.z);
       }
        if (transform.position.y <= -8f)
        {
            transform.position = new Vector3(transform.position.x, -8f, transform.position.z);
        }
      if (transform.position.y >= MaxHightLimit)
      {
          transform.position = new Vector3(transform.position.x, MaxHightLimit, transform.position.z);
      }
    }
   private void OnTriggerEnter(Collider other)
   {
       if (other.gameObject.tag == "DarkOrb" )
       {
            if (BlinkTimer <= 0f)
            {
                FindObjectOfType<SoundManagerScript>().Play("PlayerDamageSFX");

                BlinkTimer = BlinkDuration;

                HP -= 50f;
            }
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Undestructable")
        {
            if (BlinkTimer <= 0f)
            {
                FindObjectOfType<SoundManagerScript>().Play("PlayerDamageSFX");

                BlinkTimer = BlinkDuration;

                HP -= 50f;
            }
            Destroy(other.gameObject);

        }
        if (other.tag == "Event1")
        {
            EventCameraOn = true;
        }
    }
   private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Event1")
        {
            EventCameraOn = false;
        }
    }
  
}
