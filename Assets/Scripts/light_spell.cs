using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_spell : MonoBehaviour
{
    static public Vector3 target;

    private bool rot_prot = false;
    void Update()
    {
        if (!rot_prot)
        { 
            transform.rotation*=Quaternion.Euler(-4,1,1);
            rot_prot = true;
        }
        
        transform.position += transform.forward*2;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }
}
