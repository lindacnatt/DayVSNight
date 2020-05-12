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
    public void SunHit() {

        transform.RotateAround(Vector3.zero, Vector3.right, 10f);
        transform.LookAt(Vector3.zero);
    }
    public void MoonHit()
    {

        transform.RotateAround(Vector3.zero, Vector3.right, -10f);
        transform.LookAt(Vector3.zero);
    }

    
}
