using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGUI : MonoBehaviour
{
    public Texture aTexture;

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
        if (!aTexture)  //Check that there is a texture
        {
            Debug.LogError("Assign a Texture in the inspector.");
            return;
        }

        // GUI.DrawTexture(new Rect(150, 100, 1600, 900), aTexture, ScaleMode.ScaleToFit, true, 10.0F);  // Not quite good

        // Make a background box for the start menu
        GUI.Box(new Rect(200, 200, 100, 200), "Menu");

        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
        if (GUI.Button(new Rect(20, 40, 80, 20), "Start"))
        {
            Debug.Log("Start!");
            //Application.LoadLevel(1);
        }

        // Make the second button, quit application if pressed.
        if (GUI.Button(new Rect(20, 70, 80, 20), "Quit"))
        {
            Application.Quit();
        }
    }
}
