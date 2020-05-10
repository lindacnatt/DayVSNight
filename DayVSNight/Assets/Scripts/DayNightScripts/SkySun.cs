using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkySun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.right, 10f * Time.deltaTime);   // rotates around zero coordinates, around the right axis, at a defined speed. Change speed to somehow depend on health!
        transform.LookAt(Vector3.zero);
    }
}
