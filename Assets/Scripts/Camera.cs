using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform clouds1;
    public float factor0 = 1f;
    
    public Transform clouds2;
    public float factor1 = 1f;
    
    public Transform clouds3;
    public float factor2 = 1f;
    
    public Transform mountains;
    public float factor3 = 1f;
    
    /*public Transform clouds4;
    public float factor4 = 1f;
    
    public Transform clouds5;
    public float factor5 = 1f;
    
    public Transform sky;
    public float factor6 = 1f;*/
    
    private float displacement;
    private float iniCamPosFrame;
    private float nextCamPosFrame;

    private void Update()
    {
        iniCamPosFrame = transform.position.x;
        //transform.position = new Vector3(PlayerController.obj.transform.position.x, transform.position.y, transform.position.z);
        transform.position = new Vector3(PlayerController.obj.transform.position.x, PlayerController.obj.transform.position.y, transform.position.z);

    }

    private void LateUpdate()
    {
        nextCamPosFrame = transform.position.x;
        
        clouds1.position = new Vector3(clouds1.position.x + (nextCamPosFrame - iniCamPosFrame) * factor0, clouds1.position.y, clouds1.position.z);
        clouds2.position = new Vector3(clouds2.position.x + (nextCamPosFrame - iniCamPosFrame) * factor1, clouds2.position.y, clouds2.position.z);
        clouds3.position = new Vector3(clouds3.position.x + (nextCamPosFrame - iniCamPosFrame) * factor2, clouds3.position.y, clouds3.position.z);
        mountains.position = new Vector3(mountains.position.x + (nextCamPosFrame - iniCamPosFrame) * factor3, mountains.position.y, mountains.position.z);
        /*clouds4.position = new Vector3(clouds4.position.x + (nextCamPosFrame - iniCamPosFrame) * factor4, clouds4.position.y, clouds4.position.z);
        clouds5.position = new Vector3(clouds5.position.x + (nextCamPosFrame - iniCamPosFrame) * factor5, clouds5.position.y, clouds5.position.z);
        sky.position = new Vector3(sky.position.x + (nextCamPosFrame - iniCamPosFrame) * factor6, sky.position.y, sky.position.z);*/
    }
}
