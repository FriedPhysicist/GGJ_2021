using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblin : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    private GameObject gandalf;
    private AudioSource _as;
    [SerializeField] private AudioClip[] _ac;

    private bool death=false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        _as = GetComponent<AudioSource>();
    }

    
    void Update()
    { 
        gandalf=GameObject.FindWithTag("Player"); 
        attack();
    }

    void attack()
    {
        if(death)
            return;
        
        float distance = Vector3.Distance(transform.position, gandalf.transform.position)-15;
        
        anim.SetBool("run", distance > 1 && distance < 190);
        anim.SetBool("kick", distance < 1);

        if (distance > 1 && distance < 190)
        {
            transform.LookAt(new Vector3(gandalf.transform.position.x,transform.position.y,gandalf.transform.position.z));
            rb.MovePosition(transform.position+transform.forward);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("goblin"))
        { 
            death = true;
            sfx_play(0);
            anim.SetBool("death", true);
        }
    }

    void kick()
    {
        sfx_play(1);
    }
    
    void sfx_play(int clip_number)
    {
        _as.clip = _ac[clip_number];
        _as.Play();
    }
}
