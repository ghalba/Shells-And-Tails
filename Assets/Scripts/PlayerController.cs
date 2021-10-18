using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private CharacterController mycc;
    private Rigidbody rb;
    private Vector2 walkInput;
    private float jumpInput;
    [SerializeField] float Speed;
    [SerializeField] float jumpforce;

    void Start()
    {
        mycc = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }
    public void OnWalk(InputAction.CallbackContext context)
    {
        walkInput = context.ReadValue<Vector2>();
        //mycc.Move(Vector3.right * Speed);
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        jumpInput = context.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        if (walkInput.x != 0 || walkInput.y != 0)
        {
            move();
           // myanimator.SetBool("ismoving", true);
            Debug.Log("moved");
        }

        else
        {
           // myanimator.SetBool("ismoving", false);

        }
        if (jumpInput!=0)
        {
            rb.velocity += jumpforce * Vector3.up;
            Debug.Log("jumped");
        }
    }
    public void move()
    {
        float y = Mathf.Atan2(walkInput.x, walkInput.y) * Mathf.Rad2Deg;
        Vector3 Direction = new Vector3(walkInput.x, 0, walkInput.y);
        Direction.Normalize();

        Quaternion rot = Quaternion.LookRotation(Direction, Vector3.up);

        if (Direction !=Vector3.zero)
        {
            transform.forward = Direction;
        }
        transform.rotation = rot;

        rb.velocity = new Vector3(walkInput.x * Speed, rb.velocity.y, walkInput.y * Speed);
    }
}
