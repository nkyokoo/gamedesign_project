using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerproperties : MonoBehaviour
{
    public double _playerHealth = 30;
    public GameObject healthtxt;
    public GameObject deathScreen;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        healthtxt.GetComponent<Text>().text = _playerHealth.ToString();
        if (transform.transform.position.y < -100.0f)
        {
            _playerHealth = _playerHealth - 0.5;
        }

        if (_playerHealth <= 0)
        {
            Time.timeScale = 0;
            deathScreen.SetActive(true);
        }
    }
}
