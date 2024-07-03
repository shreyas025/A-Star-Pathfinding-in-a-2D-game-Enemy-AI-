using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D playerBody;
    private Animator animator;
    public GroundCollider groundCollider;
    public float movementSpeed = 5f;
    public float jumpPower = 700f;
    public bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("movement", Mathf.Abs(playerBody.velocity.x));
        animator.SetBool("isGrounded", groundCollider.isGrounded);
    }

    public void Move(float horizontalInput)
    {
        if(horizontalInput != 0f)
        {
            checkFacingDirection(horizontalInput);
            float horizontalVelocity = horizontalInput * movementSpeed;
            playerBody.velocity = new Vector2(horizontalVelocity, playerBody.velocity.y);
        }
    }

    private void checkFacingDirection(float horizontalInput)
    {
        if(facingRight && horizontalInput< 0f)
        {
            Flip();
        }
        else if(!facingRight && horizontalInput > 0f)
        {
            Flip();
        }
    }

    private void Flip() 
    {
        // change the x scale of the sprite to -1.
        var playerScale = transform.localScale;
        transform.localScale = new Vector3(playerScale.x * -1, playerScale.y, playerScale.z);
        // change the facing right to false as it is left sided.
        facingRight = !facingRight;
    }

    public void Jump()
    {
        if(groundCollider.isGrounded)
        {
            playerBody.AddForce(new Vector2(0f, jumpPower));
        }
        
    }
}
