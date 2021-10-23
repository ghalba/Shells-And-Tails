using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    [SerializeField]
    private InputAction movement;
    [SerializeField]
    private InputAction jump;

    [SerializeField]
    private float maximumSpeed;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private float jumpSpeed;

    [SerializeField]
    private float jumpButtonGracePeriod;

    [SerializeField]
    private Transform cameraTransform;

    private Animator animator;
    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;
    private float jumping;
    private void Awake()
    {
        jump.performed += ONJumpPreformed;
        jump.canceled += ONJumpPreformed;
        movement.performed += OnMovementPreformed;
        movement.canceled += OnMovementPreformed;
    }
    private void OnEnable()
    {
        jump.Enable();
        movement.Enable();
    }
    private void OnDisable()
    {
        jump.Disable();
        movement.Disable();
    }
    private void OnMovementPreformed(InputAction.CallbackContext context)
    {
        var dir = movement.ReadValue<Vector2>();
        horizontalInput = dir.x;
        verticalInput = dir.y;
    }
    private void ONJumpPreformed(InputAction.CallbackContext context)
    {
        jumping = jump.ReadValue<float>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if (horizontalInput != 0 || verticalInput != 0)
        {
            
            animator.SetBool("ismoving", true);
            Debug.Log("moved");
        }

        else
        {
            animator.SetBool("ismoving", false);

        }

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            inputMagnitude /= 2;
        }

       // animator.SetFloat("Input Magnitude", inputMagnitude, 0.05f, Time.deltaTime);

        float speed = inputMagnitude * maximumSpeed;
        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            lastGroundedTime = Time.time;
        }

        if (jumping!=0)
        {
            jumpButtonPressedTime = Time.time;
        }

        if (Time.time - lastGroundedTime <= jumpButtonGracePeriod)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;

            if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod)
            {
                ySpeed = jumpSpeed;
                jumpButtonPressedTime = null;
                lastGroundedTime = null;
                animator.SetTrigger("isJumping");
            }
        }
        else
        {
            characterController.stepOffset = 0;
        }

        Vector3 velocity = movementDirection * speed;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}

