using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.8f;

    private CharacterController charController;

    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        // Convert to world space first
        movement = transform.TransformDirection(movement);

        // Apply gravity straight down in world space

        movement.y = gravity;

        charController.Move(movement * Time.deltaTime);
    }
}
