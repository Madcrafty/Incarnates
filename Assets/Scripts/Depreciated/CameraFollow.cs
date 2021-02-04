/*--------------------------------------
    File Name: CameraFollow.cs
    Purpose: Set Camera to follow player
    Author: Ruben Antao
    Modified: 24 November 2020
----------------------------------------
    Copyright 2020 Caffeinated.
--------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset3D;
    public PlayerControls controls;

    private bool toggle;
    private Vector3 offset;

    /// <summary>
    /// Awake is called when the script instance is being loaded
    /// </summary>
    private void Awake()
    {
        controls = new PlayerControls();
        offset = offset3D;
    }
    struct Matrix2x2
    {
        public Matrix2x2(float a, float b, float c, float d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }
        public float A { get; }
        public float B { get; }
        public float C { get; }
        public float D { get; }
    }
    /// <summary>
    /// This function is called when the object becomes enabled and active
    /// </summary>
    //private void OnEnable()
    //{
    //    // Turn player controls on
    //    Controls.Debug.toggle2D.performed += Toggle2D_performed;
    //    Controls.Debug.toggle2D.Enable();
    //}

    /// <summary>
    /// Enable 2D mode
    /// </summary>
    /// <param name="obj">Input key</param>
    //private void Toggle2D_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    //{
    //    toggle = !toggle;
    //    if (toggle)
    //    {
    //        offset = offset2D;
    //    }
    //    else
    //    {
    //        offset = offset3D;
    //    }
    //}

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive
    /// </summary>
    //private void OnDisable()
    //{
    //    // Turn player controls off
    //    Controls.Debug.toggle2D.performed -= Toggle2D_performed;
    //    Controls.Debug.toggle2D.Disable();
    //}

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled
    /// </summary>
    private void FixedUpdate()
    {
        // Get desired position
        Matrix2x2 forwardMatrix = new Matrix2x2
            (target.transform.forward.x,
            target.transform.right.x,
            target.transform.forward.z,
            target.transform.right.z);

        //Vector2 forward = new Vector2(transform.forward.x, transform.forward.z);
        Matrix2x2 movementMatrix = new Matrix2x2
            (offset.z * forwardMatrix.A,
            offset.x * forwardMatrix.B,
            offset.z * forwardMatrix.C,
            offset.x * forwardMatrix.D);
        Vector2 XZOffset = new Vector2(movementMatrix.A, movementMatrix.C) + new Vector2(movementMatrix.B, movementMatrix.D);
        Vector3 finalOffset = new Vector3(XZOffset.x, offset.y, XZOffset.y);
        Vector3 desiredPosition = target.position + finalOffset;

        // Move camera smoothly to position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        // Get camera to look at target
        transform.LookAt(target);
    }
}