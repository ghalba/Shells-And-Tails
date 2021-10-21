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
    private Vector3 velocity;
    [SerializeField] float Speed;
    [SerializeField] float jumpforce;
    private float angle;
    public float turnspeed=8f;
    private float smoothinputvelocity;
    private float smoothmovetime;
    private float smoothinputMagnitude;
    private bool grounded;
    public Animator myanimator;



    void Start()
    {
        mycc = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        myanimator = GetComponent<Animator>();
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
            myanimator.SetBool("ismoving", true);
            Debug.Log("moved");
        }

        else
        {
            myanimator.SetBool("ismoving", false);

        }
        if (jumpInput!=0&&grounded)
        {
            rb.velocity += jumpforce * Vector3.up;
            myanimator.SetTrigger("isJumping");
            Debug.Log("jumped");
        }

        rb.MoveRotation(Quaternion.Euler(Vector3.up * angle));
            rb.MovePosition(rb.position + velocity * Time.deltaTime);

    }
    public void move()
    {
        Vector3 inputDirection = Vector3.zero;

        inputDirection = new Vector3(walkInput.x, 0, walkInput.y).normalized;


        float inputMagnitude = inputDirection.magnitude;
        smoothinputMagnitude = Mathf.SmoothDamp(smoothinputMagnitude, inputMagnitude, ref smoothinputvelocity, smoothmovetime);

        float targetAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg;
        angle = Mathf.LerpAngle(angle, targetAngle, Time.deltaTime * turnspeed * inputMagnitude);

        rb.velocity = new Vector3(walkInput.x * Speed, rb.velocity.y, walkInput.y * Speed);
 
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Debug.Log("is grounded");
            myanimator.SetBool("JumpEnd",true);
            grounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            myanimator.SetBool("JumpEnd", false);
            grounded = false;
        }
    }
}
