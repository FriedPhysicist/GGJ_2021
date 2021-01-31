using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ring_ : MonoBehaviour
{
    public static bool ring_taken=false;
    
    void Update()
    { 
        transform.Rotate(0,2,0);
    }
    
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponentInChildren<MeshRenderer>().enabled = false;
            ring_taken = true;
        }
    }
}
