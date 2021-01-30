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
        anim.SetBool("back",input_z<0 && !light_ball_boolean);
    }

    void movement()
    { 
        Inputs();
        
        if(light_ball_boolean || fire_ball_boolean)
            return;
        
        move_dir = transform.right * input_x + transform.forward * input_z;
        rb.MovePosition(rb.position+move_dir*speed);
    }

    bool light_ball_boolean;
    bool fire_ball_boolean;
    
    public GameObject light_spell;
    public GameObject fire_ball_spell;

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
        
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            anim.SetTrigger("spell_0");
            fire_ball_boolean = true; 
        } 
    }

    public void shoot()
    {
        RaycastHit hit; 

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        { 
            if(light_ball_boolean) Instantiate(light_spell, spell_spawn.position, Quaternion.LookRotation(Camera.main.transform.forward));
            if(fire_ball_boolean) Instantiate(fire_ball_spell, spell_spawn.position, Quaternion.LookRotation(Camera.main.transform.forward)); 
            
            global::light_spell.target = hit.transform.position;
            
            light_ball_boolean = false;
            fire_ball_boolean = false;
        }
    }
}
