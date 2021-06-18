using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerJump : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;
    PlayerMovement playerMovement;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    public void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.CompareTag("Platform") && playerMovement.isJumping)
        {
            playerMovement.isJumping = false;
            player.transform.parent = Other.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D Other)
    {
        if(Other.gameObject.CompareTag("Platform"))
        {
            player.transform.parent = null;
        }
    }
}
