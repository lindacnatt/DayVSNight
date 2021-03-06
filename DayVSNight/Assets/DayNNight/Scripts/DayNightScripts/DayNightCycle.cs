﻿using System.Collections;
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
        transform.RotateAround(Vector3.zero, Vector3.right, -60);
        transform.LookAt(Vector3.zero);
    }
    

    public void SunHit(float amount)  // Negative for sun (aka sun gets hit)
    {
        transform.RotateAround(Vector3.zero, Vector3.right, -amount);
        transform.LookAt(Vector3.zero);
        Debug.Log("Down");
    }
    public void MoonHit(float amount)  // Positive for sun (aka moon gets hit)
    {
       transform.RotateAround(Vector3.zero, Vector3.right, amount);
       transform.LookAt(Vector3.zero);
        Debug.Log("Up");
    }
    
}
