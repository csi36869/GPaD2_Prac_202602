using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.8f;
    public float pushForce = 3.0f;

    private CharacterController charController;
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        
        //transform.Translate(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime);
        //Debug.Log("Time.deltaTime=" + Time.deltaTime);
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        charController.Move(movement);
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