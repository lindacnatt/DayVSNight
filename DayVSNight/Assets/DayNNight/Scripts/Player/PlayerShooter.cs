using UnityEngine;

namespace Complete
{
    public class PlayerShooter : MonoBehaviour
    {

        public int m_PlayerNumber = 1;              
        public Rigidbody m_Bullet;                  
        public Transform m_FirePosition;          
        public float m_LaunchForce = 15f;        


        private string m_FireButton;   
        private float m_CurrentLaunchForce;               // The input axis that is used for launching shells.


        private void OnEnable()
        {
            m_CurrentLaunchForce = m_LaunchForce;
        }
         private void Start ()
        {
            m_FireButton = "Fire" + m_PlayerNumber;
            
        }

        // Update is called once per frame
        private void Update ()
        {
            if (Input.GetButtonDown (m_FireButton))
            {
                Fire ();
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
}