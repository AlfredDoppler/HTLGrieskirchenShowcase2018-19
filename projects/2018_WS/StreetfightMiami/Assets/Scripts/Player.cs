using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;

    public float maxSpeed;
    public bool facingRight = true;
    public bool isMoving = false;
    public float jumpHeight;
    bool isJumping = false;
    bool canMove = true;
    public float jumpForce = 2000f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("cyberpunk_Melee"))
        { }
        else
        {
            float move = Input.GetAxis("Horizontal");
            animator.SetFloat("speed", Mathf.Abs(move));
            if (Mathf.Abs(move) > 0.1) isMoving = true;
            if (Mathf.Abs(move) < 0.1) isMoving = false;
            rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
            if (move > 0 && !facingRight)
            {
                flip();
            }
            else if (move < 0 && facingRight)
            {
                flip();
            }

            if( Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                isJumping = true;
                animator.SetBool("isJumping", isJumping);
                animator.SetFloat("speed", 0f);
                rb.AddForce(Vector2.up * jumpForce);
            }
        }


        if (Input.GetButtonDown("Melee"))
        {
            rb.velocity = new Vector2(0, 0);
            //animator.SetFloat("speed", 0f);
            animator.Play("cyberpunk_Melee");
        }
    }

    private void OnCollisionEnter2D(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isJumping = false;
            animator.SetBool("onTheGround", isJumping);
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
