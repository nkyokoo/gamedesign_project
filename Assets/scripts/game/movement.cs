using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 1;
    public Transform GroundCheck;
    public float jumpForce;
    public GameObject hitbox;
    private bool isgrounded;
    private bool m_FacingRight;
    private float horizontalMove;
    private bool jump;
    private Rigidbody2D rb;
    private Animator anim;
    private bool canDamage;
    private GameObject enemy;
    private int jumpHeight;

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
      
        if (Input.GetAxis("Horizontal") > 0)
        {   
            
            m_FacingRight = true;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            anim.SetFloat("Speed",Math.Abs(horizontalMove));
  

        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            m_FacingRight = false;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            anim.SetFloat("Speed",Math.Abs(horizontalMove));
         
 
        }
        else
        {
              anim.SetFloat("Speed",Math.Abs(horizontalMove));
  
        }
        hitbox.SetActive(false);
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.JoystickButton2))
        {
            
           anim.SetTrigger("punching");
           Debug.Log("hello");
           hitbox.SetActive(true);
         
        }

        if (!isgrounded)
        {
            Debug.Log(jumpHeight);
            jumpHeight++;
        }
        if (isgrounded && (jumpHeight >= 90 && jumpHeight <= 139))
        {
            Debug.Log("Applying fall damage");
            var damagedhealth = GetComponent<playerproperties>().getHealth() - 20*jumpHeight;
            GetComponent<playerproperties>().setHealth(damagedhealth);
            
        }
        else if (isgrounded)
        {
            jumpHeight = 0;
        }
       
            
        
        if (isgrounded)
        {
            anim.SetBool("isJumping",false);
            jump = true;
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton0))
            {
               
                anim.SetBool("isJumping",true);
                rb.AddForce(transform.up * jumpForce);
            }
        }
    }
 }
