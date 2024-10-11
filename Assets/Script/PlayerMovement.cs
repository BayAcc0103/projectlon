using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float playerHeight;

    public Transform orientation;

    [Header("Movement")]
    public float moveSpeed;
    public float moveMultiplier;
    public float airMultiplier;
    public float counterMovement;

    public float jumpForce;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;

    [Header("Speed Limits")]
    public float maxSpeed;
    public float walkMaxSpeed;
    public float sprintMaxSpeed;
    public float airMaxSpeed;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;
    private Vector3 slopeMoveDirection;

    private Rigidbody rb;

    public TextMeshProUGUI text_speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        MyInput();
        ControlSpeed();

        if (Input.GetKeyDown(jumpKey))
        {
            // Jump
            Jump();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void ControlSpeed()
    {
        if (Input.GetKey(sprintKey))
            maxSpeed = sprintMaxSpeed;
        else
            maxSpeed = walkMaxSpeed;
    }

    private void MovePlayer()
    {
        float x = horizontalInput;
        float y = verticalInput;

        // Find actual velocity relative to where player is looking
        Vector2 mag = FindVelRelativeToLook();
        float xMag = mag.x, yMag = mag.y;

        // Counteract sliding and sloppy movement
        CounterMovement(x, y, mag);

        // If speed is larger than maxspeed, cancel out the input so you don't go over max speed
        if (x > 0 && xMag > maxSpeed) x = 0;
        if (x < 0 && xMag < -maxSpeed) x = 0;
        if (y > 0 && yMag > maxSpeed) y = 0;
        if (y < 0 && yMag < -maxSpeed) y = 0;

        moveDirection = orientation.forward * y + orientation.right * x;

        // Apply movement
        rb.AddForce(moveDirection.normalized * moveSpeed * moveMultiplier, ForceMode.Force);

        // Limit rb velocity
        Vector3 rbFlatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (rbFlatVelocity.magnitude > maxSpeed)
        {
            rbFlatVelocity = rbFlatVelocity.normalized * maxSpeed;
            rb.velocity = new Vector3(rbFlatVelocity.x, rb.velocity.y, rbFlatVelocity.z);
        }
    }

    private void Jump()
    {
        // Reset rb y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void CounterMovement(float x, float y, Vector2 mag)
    {
        float threshold = 0.01f;

        // Counter movement
        if (Mathf.Abs(mag.x) > threshold && Mathf.Abs(x) < 0.05f || (mag.x < -threshold && x > 0) || (mag.x > threshold && x < 0))
        {
            rb.AddForce(moveSpeed * orientation.transform.right * Time.deltaTime * -mag.x * counterMovement);
        }
        if (Mathf.Abs(mag.y) > threshold && Mathf.Abs(y) < 0.05f || (mag.y < -threshold && y > 0) || (mag.y > threshold && y < 0))
        {
            rb.AddForce(moveSpeed * orientation.transform.forward * Time.deltaTime * -mag.y * counterMovement);
        }
    }

    public Vector2 FindVelRelativeToLook()
    {
        float lookAngle = orientation.transform.eulerAngles.y;
        float moveAngle = Mathf.Atan2(rb.velocity.x, rb.velocity.z) * Mathf.Rad2Deg;

        float u = Mathf.DeltaAngle(lookAngle, moveAngle);
        float v = 90 - u;

        float magnitude = rb.velocity.magnitude;
        float yMag = magnitude * Mathf.Cos(u * Mathf.Deg2Rad);
        float xMag = magnitude * Mathf.Cos(v * Mathf.Deg2Rad);

        return new Vector2(xMag, yMag);
    }
}