using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public GameObject Player;
    public Rigidbody2D rb;
    public bool isJumping;


    void Update()
    {
       
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * jumpForce;
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }
    }

    void OnCollisionEnter2D(Collision2D Other)
    {
        if(Other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }

        if(Other.gameObject.CompareTag("Platform"))
        {
            this.transform.parent = Other.transform;
            isJumping = false;
        }
    }

    void OnCollisionExit2D(Collision2D Other)
    {
        if(Other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }

        if (Other.gameObject.CompareTag("Platform"))
        {
            this.transform.parent = null;
        }
    }
}
