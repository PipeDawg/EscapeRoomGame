using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementNew : MonoBehaviour
{
    [Header("Movement")]
    float moveSpeed;

    public float walkSpeed;
    public float sprintSpeed;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    [SerializeField] AudioSource walkSound;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        Inputs();
        VelocityLimiter();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void Inputs()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void VelocityLimiter()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = sprintSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }
        Vector3 limitedVelocity;
        // limit velocity if needed
        if (flatVelocity.magnitude > moveSpeed)
        {
            limitedVelocity = flatVelocity.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }

        walkSound.volume = rb.velocity.sqrMagnitude / moveSpeed;
    }
}
