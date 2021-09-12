using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float Speed = 0;
    [SerializeField]
    private float Height = 0;

    private float movementY;
    private float movementX;
    private float movementZ;

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementZ = movementVector.y;
    }

    void FixedUpdate()
    {
        movementY = 0.0f;
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity);

        if (hit.distance < Height)
        {
            movementY = 0.5f; 
        }
        else if(hit.distance > (Height+0.2f))
        {
            movementY = -(hit.distance - Height);
        }

        Vector3 movement = new Vector3(movementX, movementY, movementZ);
        movement.Normalize();
        transform.position = transform.position + (movement * Speed * Time.deltaTime);

        transform.up = hit.normal;
    }
}
