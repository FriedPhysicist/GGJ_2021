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
        anim.SetBool("forward",input_z>0);
    }

    void movement()
    {
        input_z = Input.GetAxis("Vertical");
        input_x = Input.GetAxis("Horizontal");
        
        move_dir = transform.right * input_x + transform.forward * input_z;
        rb.MovePosition(rb.position+move_dir*speed);
    }
}
