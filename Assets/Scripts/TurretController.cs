using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurretController : MonoBehaviour
{
    [SerializeField]
    private float RotationSpeed;
    [SerializeField]
    private float ShotDistance;

    private float rotationX;
    private float rotation;
    //private float movementY;

    void OnFire(InputValue FireButton)
    {
        
        RaycastHit hit;
        //Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, ShotDistance);
        
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, ShotDistance))
        {
            
            if (!hit.collider.gameObject.CompareTag("Indestructable"))
            {
                Debug.Log("Target Hit: " + hit.collider.gameObject.name);
                hit.collider.gameObject.SetActive(false);
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * ShotDistance, Color.red, 0.3f, true);
            }
            else if (hit.collider.gameObject.CompareTag("Indestructable"))
            {
                //Debug.Log("Hit Indestructable Object");
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * ShotDistance, Color.yellow, 0.3f, true);
            }
        }
        else
        {
            //Debug.Log("Missed");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * ShotDistance, Color.white, 0.3f, true);
        }
        

    }

    void OnMove(InputValue rotationValue)
    {
        Vector2 rotationVector = rotationValue.Get<Vector2>();

        rotationX = rotationVector.x;
        //movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        //Vector3 rotation = new Vector3(rotation, 0.0f, 0.0f);
        rotation = (rotationX * RotationSpeed * Time.deltaTime);



        transform.Rotate(0.0f, rotation, 0.0f);
    }
}
