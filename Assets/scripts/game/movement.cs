using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements.StyleEnums;

public class movement : MonoBehaviour
{
    public float speed = 1;
    public Transform GroundCheck;
    private bool isgrounded;
    private bool m_FacingRight;
    private float horizontalMove;
    private bool jump;
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    
    }

    void FixedUpdate()
    {
        isgrounded = Physics2D.Linecast(transform.position, GroundCheck.position,
            1 << LayerMask.NameToLayer("Ground"));

         
        horizontalMove = Input.GetAxisRaw("Horizontal")*speed;
        anim.SetFloat("Speed",Math.Abs(horizontalMove));
        if (Input.GetKey(KeyCode.D))
        {   
            
            m_FacingRight = true;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(Vector3.right * Time.deltaTime * speed);
  

        }
        else if (Input.GetKey(KeyCode.A))
        {
            m_FacingRight = false;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(Vector3.right * Time.deltaTime * speed);
         
 
        }
        
             

        if (isgrounded)
        { 
            jump = true;
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton0))
            {
               
                Debug.Log("Jump should be set to true");
                rb.AddForce(new Vector2(0, 1), ForceMode2D.Impulse);
            }
        }
    }

    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.layer == 9)
        {
            isgrounded = true;
        }
    }

    void OnCollisionExit(Collision theCollision)
    {
        if (theCollision.gameObject.layer == 9)
        {
            isgrounded = false;
        }
    }
}