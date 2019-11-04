using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hostileNPC : MonoBehaviour
{
    //public npc values set by unity
    public double npcHealth;
    public float speed;
    public GameObject enemyGroundCheck;
    public GameObject enemyLeftCheck;
    public GameObject enemyRightCheck;
    public GameObject enemyHPBar;
    public float jumpForce;
    private Rigidbody2D rb;

    
    //private variable only needed for the script and should not be changed
    private bool isgrounded;
    private bool canNotMoveLeft;
    private bool canNotMoveRight;
    private float hittimer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyHPBar.SetActive(false);
        hittimer += Time.deltaTime;
        
        isgrounded = Physics2D.Linecast(transform.position, enemyGroundCheck.transform.position,
            1 << LayerMask.NameToLayer("Ground"));
        canNotMoveLeft = Physics2D.Linecast(transform.position, enemyLeftCheck.transform.position,
            1 << LayerMask.NameToLayer("Ground"));
        canNotMoveRight = Physics2D.Linecast(transform.position, enemyRightCheck.transform.position,
            1 << LayerMask.NameToLayer("Ground"));

       
        if (canNotMoveLeft)
        { 
            
            if(isgrounded){
                rb.AddForce(transform.up * jumpForce);
            }
            
        }
        else if (canNotMoveRight)
        {
            Debug.Log("hello world");
            if(isgrounded){
                rb.AddForce(transform.up * jumpForce);
            }
        }
        else 
        {
            transform.position=Vector3.MoveTowards(transform.position,GameObject.Find("player").transform.position, speed);
      
        }
        if (npcHealth <=0 )
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {        enemyHPBar.GetComponent<Text>().text = npcHealth.ToString();
        if (other.CompareTag("punch") && hittimer>0.5f)
        {
            npcHealth = npcHealth - 2;
            enemyHPBar.GetComponent<Text>().text = npcHealth.ToString();
            enemyHPBar.SetActive(true); 
            rb.AddForce(Vector2.right*50f);
            hittimer = 0f;
        }
    }

}
