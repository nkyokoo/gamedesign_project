﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerchecker : MonoBehaviour
{
    private int Xbox_One_Controller = 0;
    private int PS4_Controller = 0;
    void Update()
    {
        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            print(names[x].Length);
            if (names[x].Length == 19)
            {
                print("PLAYSTATION CONTROLLER IS CONNECTED");
                PS4_Controller = 1;
                Xbox_One_Controller = 0;
            }
            if (names[x].Length == 33)
            {
                print("XBOX CONTROLLER IS CONNECTED");
                //set a controller bool to true
                PS4_Controller = 0;
                Xbox_One_Controller = 1;
 
            }
        }
 
 
        if(Xbox_One_Controller == 1)
        {
            //do something
        }
        else if(PS4_Controller == 1)
        {
            //do something
        }
        else
        {
            // there is no controllers
        }
    }
}
