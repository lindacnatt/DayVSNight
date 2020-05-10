﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGUI : MonoBehaviour
{


    public Texture NightTexture;
    public Texture DayTexture;
    public GUIStyle styleBox;
    public GUIStyle styleButton;

    public bool MOONWINNER = true;
    public bool SUNWINNER = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        if (!NightTexture  || !DayTexture)  //Check that there is a texture
        {
            Debug.LogError("Assign a Texture in the inspector.");
            return;
        }

        int screenwidth = 700;
        int buttonwidth = 80;
        int buttonheight = 40;
        float marginx = (1280 - screenwidth) / 2;
        int marginy = 200;


        // GUI.DrawTexture(new Rect(150, 100, 1600, 900), aTexture, ScaleMode.ScaleToFit, true, 10.0F);  // Not quite good

        // Make a background box for the scene
        if (MOONWINNER)
        {
            GUI.DrawTexture(new Rect(0, 0, 1280, 800), NightTexture, ScaleMode.ScaleToFit, true);

        }
        if (SUNWINNER)
        {
            GUI.DrawTexture(new Rect(0, 0, 1280, 800), DayTexture, ScaleMode.ScaleToFit, true);

        }


        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
        if (GUI.Button(new Rect(marginx + (screenwidth - buttonwidth) / 2, marginy + 140, buttonwidth, buttonheight), "Start"))
        {
            Debug.Log("Play Again!");
            //Application.LoadLevel(1);
        }

        // Make the second button, quit application if pressed.
        if (GUI.Button(new Rect(marginx + (screenwidth - buttonwidth) / 2, marginy + buttonheight + 160, buttonwidth, buttonheight), "Quit"))
        {
            Application.Quit();
        }
        GUI.skin.button = styleButton;

        GUI.Box(new Rect(marginx + screenwidth, marginy, 200, 300), "Highscore");
        GUI.skin.box = styleBox;

    }
}
