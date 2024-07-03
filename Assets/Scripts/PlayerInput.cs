using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private float horizontalInput;
    private PlayerMovement playerMovement;
    private bool jumpPressed;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        // unity will know the horizontal input because it is predifined as a,d or l,r.
        horizontalInput = Input.GetAxis("Horizontal");

        if(!jumpPressed)
        {
            // "Jump" is registered as spacebar in our engine.
            jumpPressed = Input.GetButtonDown("Jump");
        }
    }

    private void FixedUpdate()
    {
        if(horizontalInput != 0f)
        {
            playerMovement.Move(horizontalInput);
        }

        if(jumpPressed)
        {
            playerMovement.Jump();
            jumpPressed = false;
        }
    }
}
