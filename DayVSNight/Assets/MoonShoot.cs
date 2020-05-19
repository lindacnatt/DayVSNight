using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonShoot : MonoBehaviour
{           
    public Rigidbody m_Bullet;                  
    public Transform m_FireForward;
    public Transform m_FireRight; 
    public Transform m_FireLeft;
    public Transform m_FireBack; 

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
        //Forward
        Rigidbody bulletInstance = Instantiate (m_Bullet, m_FireForward.position, m_FireForward.rotation) as Rigidbody; 
        bulletInstance.velocity = m_CurrentLaunchForce * (m_FireForward.forward); 

        //Right
        Rigidbody bulletInstance2 = Instantiate (m_Bullet, m_FireRight.position, m_FireRight.rotation) as Rigidbody; 
        bulletInstance2.velocity = m_CurrentLaunchForce * (m_FireRight.right); 

        //Left
        Rigidbody bulletInstance3 = Instantiate (m_Bullet, m_FireLeft.position, m_FireLeft.rotation) as Rigidbody; 
        bulletInstance3.velocity = m_CurrentLaunchForce * (m_FireLeft.right *-1); 
        //Back
        Rigidbody bulletInstance4 = Instantiate (m_Bullet, m_FireBack.position, m_FireBack.rotation) as Rigidbody; 
        bulletInstance4.velocity = m_CurrentLaunchForce * (m_FireBack.forward *-1);    
    } 
}
