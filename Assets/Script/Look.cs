using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    public Transform cam;
    public float xRotation = 0.0f;

    public float xSens = 30.0f;
    public float ySens = 30.0f;

   
    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

     
        xRotation -= (mouseY * Time.deltaTime) * ySens; 
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);  

        
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

      
        transform.Rotate(Vector3.up * mouseX * Time.deltaTime * xSens);
    }
}
