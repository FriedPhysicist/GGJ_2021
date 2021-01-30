using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gandalf : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    AudioSource _as;

    private float input_z;
    private float input_x;
    private Vector3 move_dir;
    public float speed;
    
    [SerializeField] public AudioClip[] _ac; 
    
    void Start()
    {
        anim = GetComponent<Animator>();
        rb=GetComponent<Rigidbody>();
        _as=GetComponent<AudioSource>(); 
    } 
    
    void Update()
    { 
        animations(); 
    }

    void FixedUpdate()
    { 
        movement();
    }

    void animations()
    { 
        anim.SetBool("forward",input_z>0 && !light_ball_boolean);
    }

    void movement()
    { 
        Inputs();
        
        move_dir = transform.right * input_x + transform.forward * input_z;
        rb.MovePosition(rb.position+move_dir*speed);
    }

    bool light_ball_boolean;
    public GameObject light_spell;
    public Transform spell_spawn;
    
    void Inputs()
    { 
        input_z = Input.GetAxis("Vertical");
        input_x = Input.GetAxis("Horizontal"); 
        
        //cast skills 
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            anim.SetTrigger("spell_0");
            light_ball_boolean = true; 
        } 
    }

    public void lightball()
    {
        RaycastHit ray; 

        if (Physics.Raycast(spell_spawn.position, Camera.main.transform.TransformDirection(Camera.main.transform.forward), out ray))
        {
            //if(ray.collider==null) light_spell.transform.rotation = ray.transform.rotation; 
            
            GameObject light_spell_copy = Instantiate(light_spell, spell_spawn.position, Quaternion.identity);
            if(ray.transform != null) light_spell.GetComponent<light_spell>().target = ray.point;
            
            light_ball_boolean = false;
        }
    }
}
