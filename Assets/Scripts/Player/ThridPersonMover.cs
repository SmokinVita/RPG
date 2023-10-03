using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThridPersonMover : MonoBehaviour
{
    [SerializeField] private float _turnSpeed = 1000f;

    private Rigidbody _rb;
    private float _moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if (_rb == null)
        {
            Debug.LogError("Rigidbody is NULL!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        var mouseMovement = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseMovement * Time.deltaTime * _turnSpeed, 0);
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        var velocity = new Vector3(horizontal, 0, vertical);
        velocity *= _moveSpeed * Time.fixedDeltaTime;
        Vector3 offset = transform.rotation * velocity;
        _rb.MovePosition(transform.position + offset);

    }
}
