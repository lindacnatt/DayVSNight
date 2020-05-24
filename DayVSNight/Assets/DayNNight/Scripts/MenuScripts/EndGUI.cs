using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EndGUI : MonoBehaviour
{


    public Texture Texture;
    public GUIStyle styleBox;
    public GUIStyle styleButton;

    private string playerScore;
    private string topScore;

    void Start()
    {
 
    }

    void Awake()
    {
        
        Debug.Log("End screen player score: " + PlayerPrefs.GetFloat("PlayerScore"));
        playerScore = PlayerPrefs.GetFloat("PlayerScore").ToString();
        topScore = PlayerPrefs.GetFloat("TopScore").ToString();
        Debug.Log("End screen top score:" + topScore);
    }
    void OnGUI()
    {
        if (!Texture)  //Check that there is a texture
        {
            Debug.LogError("Assign a Texture in the inspector.");
            return;
        }

        int screenwidth = Screen.width;
        int buttonwidth = 80;
        int buttonheight = 40;
        float marginx = (screenwidth - 700) / 2;
        int marginy = (Screen.height-400)/2;

        // Make a background box for the scene
      
        GUI.DrawTexture(new Rect(marginx, marginy, 400, 400), Texture, ScaleMode.ScaleToFit, true);

     

        // Make the button, quit application if pressed.
        if (GUI.Button(new Rect(marginx + (400 - buttonwidth) / 2, marginy + buttonheight, buttonwidth, buttonheight), "Quit"))
        {
            Application.Quit();
        }
        GUI.skin.button = styleButton;


        
        GUIContent content = new GUIContent("Your score: " + playerScore + "\n"+ "Top score: "+ topScore);

        GUI.Box(new Rect(marginx + 100, marginy + 3 * buttonheight, 200, 200), content);
        GUI.skin.box = styleBox;

    }
}
