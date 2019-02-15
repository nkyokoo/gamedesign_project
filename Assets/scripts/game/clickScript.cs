using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clickScript : MonoBehaviour
{
    public void teleportToPlanet(String planetName)
    {
        SceneManager.LoadScene(planetName);
    }

    private void OnMouseEnter()
    {
        transform.localScale *= 1.1f;
      //  throw new System.NotImplementedException();
    }

    private void OnMouseExit()
    {
        transform.localScale *= .9f;
     

       // throw new System.NotImplementedException();
    }
}
