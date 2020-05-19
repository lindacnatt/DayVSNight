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
        transform.RotateAround(Vector3.zero, Vector3.right, -30f);
        transform.LookAt(Vector3.zero);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SunHit(float amount)  // Positive for sun (aka moon gets hit)
    {
        transform.RotateAround(Vector3.zero, Vector3.right, amount);
        transform.LookAt(Vector3.zero);
    }
    public void MoonHit(float amount)  // Positive for moon (aka sun gets hit)
    {
       transform.RotateAround(Vector3.zero, Vector3.right, -amount);
       transform.LookAt(Vector3.zero);
    }

    // Alternative: Boolean on player defining if sun or not, Hit(boolean sun) function which checks if the player that got hit is the sun, in that cas do SunHit, otherwise do MoonHit -- not sure how to declare the lights though!!

    
}
