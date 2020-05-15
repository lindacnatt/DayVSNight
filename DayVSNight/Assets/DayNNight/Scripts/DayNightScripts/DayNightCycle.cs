using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DayNightCycle : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        transform.RotateAround(Vector3.zero, Vector3.right, -50f);
        transform.LookAt(Vector3.zero);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SunHit() {  //Sun gets hit, sun sets

        transform.RotateAround(Vector3.zero, Vector3.right, 10f);
        transform.LookAt(Vector3.zero);
    }
    public void MoonHit()  // Moon gets hit, sun rises
    {

        transform.RotateAround(Vector3.zero, Vector3.right, -10f);
        transform.LookAt(Vector3.zero);
    }

    // Alternative: Boolean on player defining if sun or not, Hit(boolean sun) function which checks if the player that got hit is the sun, in that cas do SunHit, otherwise do MoonHit -- not sure how to declare the lights though!!

    
}
