using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblin : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    private GameObject gandalf;

    private bool death=false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
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
        
        anim.SetBool("run", distance > 1 && distance < 45);
        anim.SetBool("kick", distance < 1);

        if (distance > 1 && distance < 60)
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
            anim.SetBool("death", true);
        }
    }
}
