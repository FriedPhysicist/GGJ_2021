using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_spell : MonoBehaviour
{
    public Vector3 target;
    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,target,0.5f);
    }
}
