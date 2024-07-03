using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollider : MonoBehaviour
{

    public bool isGrounded = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.layer == 8)
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            isGrounded = false;
        }
    }
}
