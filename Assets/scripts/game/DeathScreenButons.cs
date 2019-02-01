using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenButons : MonoBehaviour
{

   public void mainMenu()
   {
      SceneManager.LoadScene(1);
   }

   public void Restart()
   {
      SceneManager.LoadScene(2);
   }
}
