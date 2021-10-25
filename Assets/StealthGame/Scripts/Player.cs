using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public event System.Action onReachendlevel;
    public float moveSpeed = 7;
    float smoothinputMagnitude;
    float smoothinputvelocity;
    float angle;
    public float smoothmovetime = .1f;
    public float turnspeed = 8;
    Vector3 velocity;

    Rigidbody rigidbody;
    bool disabled;

    private void Start()
    {
       rigidbody = GetComponent<Rigidbody>();
        Guard.onguardspotedPlayer += OnDisable;
    }

    void Update () {
        Vector3 inputDirection = Vector3.zero;
        if(!disabled) {
            inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        }

       
        float inputMagnitude = inputDirection.magnitude;
        smoothinputMagnitude = Mathf.SmoothDamp(smoothinputMagnitude, inputMagnitude, ref smoothinputvelocity, smoothmovetime);

        float targetAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg;
        angle = Mathf.LerpAngle(angle, targetAngle, Time.deltaTime * turnspeed * inputMagnitude);

        velocity = transform.forward * moveSpeed * smoothinputMagnitude;
	}

    private void OnDisable()
    {
        disabled = true;
    }
    private void FixedUpdate()
    {
        rigidbody.MoveRotation(Quaternion.Euler(Vector3.up * angle));
        rigidbody.MovePosition(rigidbody.position + velocity * Time.deltaTime);
    }

    private void OnDestroy()
    {
        Guard.onguardspotedPlayer -= OnDisable;
    }

    private void OnTriggerEnter(Collider hitCollider)
    {
        if (hitCollider.tag == "Finish")
        {
            OnDisable();
            if (onReachendlevel != null)
            {
                onReachendlevel();
            }
        }
    }
}
