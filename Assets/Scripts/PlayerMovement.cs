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
    private void Update()
    {
        var movement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movement, 0) * movementSpeed * Time.deltaTime;
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb2d.velocity.y) < 0.0001f)
        {
            Jump();
        }

        if (!Mathf.Approximately(0, movement))
        {
            transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }
    }

    private void Jump()
    {
        rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}
