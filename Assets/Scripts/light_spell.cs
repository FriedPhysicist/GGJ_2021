using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_spell : MonoBehaviour
{
    static public Vector3 target;
    
    void Update()
    {
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
