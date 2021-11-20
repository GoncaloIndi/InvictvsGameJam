using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float jumpForce;
    private float movementX;
    private Rigidbody2D rb2d;

    public Animator animator;
    public bool CanMove;

    private SoundManager SoundManager;
    public static bool IsFacingLeft = true;
    public bool DebugIsFacingLeft;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        CanMove = true;
        SoundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
    private void Update()
    {
        DebugIsFacingLeft = PlayerMovement.IsFacingLeft;

        movementX = Input.GetAxisRaw("Horizontal");

        if (movementX == 0)
        {
            animator.SetBool("IsRunning", false);
        }
        else
        {
            animator.SetBool("IsRunning", true);
        }
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb2d.velocity.y) < 0.0001f)
        {
            Jump();
        }

        Vector3 characterScale = transform.localScale;
        if (movementX < 0)
        {
            characterScale.x = -1;
            IsFacingLeft = true;
        }
        if (movementX > 0)
        {
            characterScale.x = 1;
            IsFacingLeft = false;
        }
        transform.localScale = characterScale;

        // if (!Mathf.Approximately(0, movementX))
        // {
        //     transform.rotation = movementX > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        //     IsFacingLeft = !IsFacingLeft;
        // }

    }

    void FixedUpdate()
    {
        if (CanMove)
        {
            rb2d.velocity = new Vector2(movementX * movementSpeed, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
    }

    private void Jump()
    {
        rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        SoundManager.PlaySound("Jump");
    }
}
