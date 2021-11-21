using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float MovementSpeed;
    [SerializeField]
    private float jumpForce;
    private float movementX;
    private Rigidbody2D rb2d;

    private bool isJumping = false;

    //public GameObject NewPlayerPrefab;

    [SerializeField]
    private GameObject woman;

    public PlayerShooter stopFire;

    private bool isOnScene = true;

    public bool canJump = false;

    public GameObject MusicSad;
    public GameObject MusicEpic;

    public Animator animator;
    public bool CanMove;
    [SerializeField]
    private bool isOnEndThing = false;

    private SoundManager SoundManager;
    public GameObject RunningSoundObject;
    
    public static bool IsFacingLeft = true;
    public bool DebugIsFacingLeft;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        isOnScene = true;
        CanMove = true;
        canJump = false;
        MovementSpeed = 0;
        stopFire = this.gameObject.GetComponent<PlayerShooter>();
        SoundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }



    private void Update()
    {
        DebugIsFacingLeft = PlayerMovement.IsFacingLeft;

        if(MovementSpeed != 0)
        {

             movementX = Input.GetAxisRaw("Horizontal");
        }

        

        if(movementX != 0)
        {
            RunningSoundObject.SetActive(true);
        }
        else if(movementX == 0)
        {
            RunningSoundObject.SetActive(false);
        }

        if (movementX == 0 && !isOnEndThing && !isOnScene)
        {
            animator.SetBool("IsRunning", false);
        }
        else
        {
            animator.SetBool("IsRunning", true);
        }
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb2d.velocity.y) < 0.0001f && canJump == true)
        {
            Jump();
        }

        if(isJumping)
        {
            JumpAnimations();
        }

        

        Vector3 characterScale = transform.localScale;
        if (movementX < 0 && !isOnEndThing)
        {
            characterScale.x = -0.6f;
            IsFacingLeft = true;
        }
        if (movementX > 0 && !isOnEndThing)
        {
            characterScale.x = 0.6f;
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
            rb2d.velocity = new Vector2(movementX * MovementSpeed, rb2d.velocity.y);
        }
        else if (isOnScene)
        {
            rb2d.velocity = new Vector2(5, rb2d.velocity.y);
            Debug.Log("daaaaa");
        }
        else if(!isOnEndThing)
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        else if(isOnEndThing)
        {
            rb2d.velocity = new Vector2(-MovementSpeed, rb2d.velocity.y);
        }
        
    }

    private void Jump()
    {
        isJumping = true;
        MovementSpeed = 5;
        animator.SetTrigger("Jump");
        rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        SoundManager.PlaySound("Jump");
    }

    private void JumpAnimations()
    {
        if(Mathf.Abs(rb2d.velocity.y) < 0.00000001f)
        {
            animator.SetTrigger("Ground");
            Invoke("ResetSpeed", .1f);
            MovementSpeed = 2f;
            isJumping = false;
        }
    }

    public void StartEndThing()
    {
        isOnEndThing = true;
        CanMove = false;
        Vector3 characterScale = transform.localScale;
        characterScale.x = -0.6f;
        transform.localScale = characterScale;
        MovementSpeed = 2f;
        animator.SetBool("IsRunning", true);
        Destroy(this.gameObject.GetComponent<PlayerShooter>());

    }

    public void StartWalkSequence()
    {
        StartCoroutine("StartWalk");
        MovementSpeed = 5;
    }

    public IEnumerator StartWalk()
    {
        Vector3 characterScale = transform.localScale;
        characterScale.x = 0.6f;
        transform.localScale = characterScale;

        Vector3 playerPos = transform.position;
        
        transform.position = playerPos;
        animator.SetBool("IsRunning", true);
        CanMove = false;
        yield return new WaitForSeconds(.1f);
        playerPos.y = -4.5f;
        yield return new WaitForSeconds(1);
        MusicSad.SetActive(false);
        MusicEpic.SetActive(true);
        woman.SetActive(false);
        CanMove = true;
        canJump = true;
        isOnScene = false;
        stopFire.canShoot = true;
    }

    private void ResetSpeed()
    {
        MovementSpeed = 5;
    }
}
