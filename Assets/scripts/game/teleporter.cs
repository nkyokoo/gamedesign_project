using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporter : MonoBehaviour
{
    public GameObject teleportationMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        {
            try
            {
                if (other.gameObject.CompareTag("Player"))
                {
                    teleportationMenu.SetActive(true);
                    Debug.Log("player is on teleporter");
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            } 
           
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            teleportationMenu.SetActive(false);
            Debug.Log("player is not on teleporter");
                    
        }
    }
}
