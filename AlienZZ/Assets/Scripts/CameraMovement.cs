﻿using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speedH = 2;
    public float speedV = 2;

    float yaw = 0;
    float pitch = 0;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0);
    }
}