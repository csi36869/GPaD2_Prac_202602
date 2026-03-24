using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.8f;
    public float sprintSpeed = 12.0f;
    public float jumpForce = 5.0f;
    public float pushForce = 3.0f;

    private CharacterController charController;
    private float verticalVelocity;

    public const float baseSpeed = 6.0f;

    void OnEnable()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    void OnDisable()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    private void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
    }

    // Update is called once per frame
    void Update()
    {
        //Added Sprint
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;
        float deltaX = Input.GetAxis("Horizontal") * currentSpeed;
        float deltaZ = Input.GetAxis("Vertical") * currentSpeed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, currentSpeed);

        //Added Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity = jumpForce; // instantly set upward velocity
        }


        // Convert to world space first
        movement = Camera.main.transform.TransformDirection(movement);

        // Apply gravity straight down in world space
        // --- Gravity ---
        verticalVelocity += gravity * Time.deltaTime;
        movement.y = verticalVelocity;

        charController.Move(movement * Time.deltaTime);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //contact = hit;
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body != null && !body.isKinematic)
        {
            body.linearVelocity = hit.moveDirection * pushForce;
        }
    }
}
