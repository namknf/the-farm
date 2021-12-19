using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float JumpForce;
    private float moveInput;
    public float checkRadius;

    private Rigidbody2D rigic;

    public LayerMask whatIsGround;

    private bool facingRight = true;
    private bool isGrounded;

    public Transform feetPos;

    private Animator anim;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }
    void Start()
    {
        rigic = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal"); 
        rigic.velocity = new Vector2(moveInput * speed, rigic.velocity.y);

        if(facingRight == false && moveInput > 0)
        {
            Flip();

        }
        else if(facingRight == true && moveInput < 0)
        {
            Flip();
        }

        if(moveInput == 0)
        {
            anim.SetBool("IsRunning", false);
        }
        else
        {
            anim.SetBool("IsRunning", true);
        }
    }

    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rigic.velocity = Vector2.up * JumpForce;
            anim.SetTrigger("TakeOff");
        }

        if(isGrounded == true)
        {
            anim.SetBool("IsJumping", false);
        }
        else
        {
            anim.SetBool("IsJumping", true);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

        if(moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 360, 0);
        }
        else if(moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}