using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMotor : MonoBehaviour
{
    private PlayerControls controls;
    private Vector2 inputDirection;
    private Rigidbody rb;
    private float Speed = 200;
    private void Awake()
    {
        controls = new PlayerControls();
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        controls.Enable();
        controls.Player.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
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
    private void Move(Vector2 dir)
    {
        inputDirection = dir;
    }
    private void OnDisable()
    {
        controls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerVelocity(inputDirection);
    }
    private void PlayerVelocity(Vector2 dir)
    {
        Matrix2x2 forwardMatrix = new Matrix2x2
            (transform.forward.x,
            transform.right.x,
            transform.forward.z,
            transform.right.z);

        //Vector2 forward = new Vector2(transform.forward.x, transform.forward.z);
        Matrix2x2 movementMatrix = new Matrix2x2
            (dir.y * forwardMatrix.A,
            dir.x * forwardMatrix.B,
            dir.y * forwardMatrix.C,
            dir.x * forwardMatrix.D);

        Vector2 playerVelocity = new Vector2(movementMatrix.A, movementMatrix.C) + new Vector2(movementMatrix.B, movementMatrix.D);
        playerVelocity = playerVelocity * Speed * Time.deltaTime;
        rb.velocity = new Vector3(playerVelocity.x, rb.velocity.y, playerVelocity.y);
    }
}
