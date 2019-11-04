using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerproperties : MonoBehaviour
{
    public double _playerHealth;
    public GameObject healthtxt;
    public GameObject deathScreen;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        healthtxt.GetComponent<Text>().text = _playerHealth.ToString();
        if (transform.transform.position.y < -50.0f)
        {
            _playerHealth = _playerHealth - 0.1;
        }

        if (_playerHealth <= 0)
        {
            Time.timeScale = 0;
            deathScreen.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            _playerHealth = _playerHealth - 1;
            rb.AddForce(Vector2.left * 100f);
        }
    }

    public double getHealth()
    {
        double returnedHealth = _playerHealth;
        return returnedHealth;
    }

    public void setHealth(double passedHealth)
    {
        Debug.Log(passedHealth);
        _playerHealth = passedHealth;
    }
}