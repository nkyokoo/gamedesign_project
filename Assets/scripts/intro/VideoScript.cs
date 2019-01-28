using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoScript : MonoBehaviour
{
    public VideoPlayer myVid;
    // Start is called before the first frame update
    void Start()
    {
       
        myVid.loopPointReached += LoadScene;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.JoystickButton1) ||  Input.GetKey(KeyCode.JoystickButton0))
        {
            SceneManager.LoadScene (1);
        }

  
        
    }
    void LoadScene(VideoPlayer vp)
    {
        SceneManager.LoadScene( 1 );
    }
}
