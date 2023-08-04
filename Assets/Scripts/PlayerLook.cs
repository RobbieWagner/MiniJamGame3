using System;﻿
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour {

    [SerializeField] private Transform cameraT;

    [SerializeField] private float sensitivityX = 1f;
    [SerializeField] private float sensitivityY = 1f;
    private float mouseX;
    private float mouseY;
    [SerializeField] private float xClamp = 85f;
    private float xRotation;

    PlayerControls playerControls;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerControls = new PlayerControls();
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, mouseX * Time.deltaTime);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);

        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = xRotation;
        cameraT.eulerAngles = targetRotation;
    }

    public void OnLook(InputValue value)
    {
        Vector2 mouseInput = value.Get<Vector2>();
        mouseX = mouseInput.x * sensitivityX;
        mouseY = mouseInput.y * sensitivityY;
    }

    // public void OnLookX(InputValue value)
    // {
    //     float mouseInputX = value.Get<float>();
    //     mouseX = mouseInputX * sensitivityX;
    // }

    // public void OnLookY(InputValue value)
    // {
    //     float mouseInputY = value.Get<float>();
    //     mouseY = mouseInputY * sensitivityY;
    // }
}