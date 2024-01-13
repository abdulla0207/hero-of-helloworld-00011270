using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Transform playerBody;


    [Header("Look")]
    public float LookSpeed;


    float xRotation = 0f;


    // Update is called once per frame
    void Update()
    {
        xRotation -= Input.GetAxis("Mouse Y") * LookSpeed * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -40f, 40f);
        

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * LookSpeed * Time.deltaTime);
    }
}
