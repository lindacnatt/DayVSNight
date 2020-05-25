using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGUI : MonoBehaviour
{
    public Texture aTexture;
    public GUIStyle styleButton;


   

    void OnGUI()
    {

        if (!aTexture)  //Check that there is a texture
        {
            Debug.LogError("Assign a Texture in the inspector.");
            return;
        }
        
        int screenwidth = Screen.width;
        int buttonwidth = 80;
        int buttonheight = 40;
        float marginx = (screenwidth-700)/2;
        int marginy = 200;
       


        // Make a background box for the start menu
        GUI.DrawTexture(new Rect(0, 0, screenwidth, Screen.height), aTexture, ScaleMode.ScaleToFit, true);


        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
        if (GUI.Button(new Rect(marginx+(700-buttonwidth)/2, marginy+140, buttonwidth, buttonheight), "Start"))
        {
            Debug.Log("Start!");
            SceneManager.LoadScene(0);
        }

        // Make the second button, quit application if pressed.
        if (GUI.Button(new Rect(marginx + (700 - buttonwidth) / 2, marginy + buttonheight + 160, buttonwidth, buttonheight), "Quit"))
        {
            Application.Quit();
        }
        GUI.skin.button = styleButton;

    }
}
