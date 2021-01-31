using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golem : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    private GameObject gandalf;
    private AudioSource _as; 
    [SerializeField] private AudioClip[] _ac;

    private int health=100;
    public float stay_away_distance;
    public float run_away_distance;

    static public bool death=false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        _as = GetComponent<AudioSource>();
    }

    
    void Update()
    { 
        gandalf=GameObject.FindWithTag("Player"); 
        anim.SetBool("roar_0",ring_.ring_taken && !can_attack);
        if(!_as.isPlaying && ring_.ring_taken && !can_attack && transform.localScale.x < 1f) sfx_play(0); 
        attack();
    }

    private bool can_attack = false;
    void attack()
    { 
        if (ring_.ring_taken && !can_attack)
        { 
            if (transform.localScale.x < 1f) transform.localScale *= 1.3f; 
        } 
        
        if(death || !ring_.ring_taken || !can_attack)
            return; 
        
        float distance = Vector3.Distance(transform.position, gandalf.transform.position)-15; 
        
        anim.SetBool("run", distance > stay_away_distance && distance < run_away_distance);
        anim.SetBool("smash", distance < stay_away_distance);

        if (distance > stay_away_distance && distance < run_away_distance)
        {
            transform.LookAt(new Vector3(gandalf.transform.position.x,transform.position.y,gandalf.transform.position.z));
            rb.MovePosition(transform.position+transform.forward);
        }

        if (health<=0)
        { 
            anim.SetBool("death", true);
            death = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("goblin"))
        {
            health -=10;
        }
    }

    void step()
    {
        sfx_play(1);
    }

    public void roar()
    {
        can_attack = true;
    }
    
    void sfx_play(int clip_number)
    {
        _as.clip = _ac[clip_number];
        _as.Play();
    }
}
