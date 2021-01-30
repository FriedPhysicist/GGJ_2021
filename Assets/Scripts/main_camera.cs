using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class main_camera : MonoBehaviour 
{

    public float mouseSensivity=1f;
    public Transform playerBody; 
    float xRotation; 

    void Start()
    { 
        playerBody=transform.parent; 
    } 

    void Update()
    {   
        if(playerBody==null)
            playerBody=transform.parent;

        float mouseX=Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;        
        float mouseY=Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;        

        xRotation-=mouseY;
        xRotation= Mathf.Clamp(xRotation, -90f,90f);

        transform.localRotation= Quaternion.Euler(xRotation,0f,0f); 
        if(playerBody!=null) playerBody.Rotate(Vector3.up*mouseX); 
    } 
}