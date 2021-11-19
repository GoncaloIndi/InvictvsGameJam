using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float jumpForce;
    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        var movement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movement, 0) * movementSpeed / 20;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb2d.velocity.y) < 0.0001f)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}
