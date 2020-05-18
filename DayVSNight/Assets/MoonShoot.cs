using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonShoot : MonoBehaviour
{
    public int m_PlayerNumber = 1;              
    public Rigidbody m_Bullet;                  
    public Transform m_FirePosition;          
    public float m_LaunchForce = 15f;  
    
    private float m_CurrentLaunchForce;    
    private float ActionTime = 0.0f;
    public float Period = 2f;

   private void OnEnable()
        {
            m_CurrentLaunchForce = m_LaunchForce;
        }


    private void Update()
    {
        if (Time.time > ActionTime) 
        {
        ActionTime += Period;
        Fire();
        }
       
    }

    private void Fire ()
    {

        // Create an instance of the bullet and store a reference to it's rigidbody.
        Rigidbody bulletInstance =
            Instantiate (m_Bullet, m_FirePosition.position, m_FirePosition.rotation) as Rigidbody;

        // Set the bullet's velocity to the launch force in the fire position's forward direction.
        bulletInstance.velocity = m_CurrentLaunchForce * m_FirePosition.forward; 
    } 
}
