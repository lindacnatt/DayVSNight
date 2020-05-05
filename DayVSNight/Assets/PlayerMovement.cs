using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int m_PlayerNumber = 1;
    public float m_Speed = 12f;
    public float m_TurnSpeed = 180f;

    private string m_MovementAxisName;
    private string m_TurnAxisName;
    private Rigidbody m_Rigidbody;
    private float m_MovementInputValue;
    private float m_TurnInputValue;

    private void Awake(){
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable(){
        m_Rigidbody.isKinematic = false;
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_MovementAxisName = "Vertical" + m_PlayerNumber;
        m_TurnAxisName = "Horizontal" + m_PlayerNumber; 
    }

    // Update is called once per frame
    void Update()
    {
        m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
        m_TurnInputValue = Input.GetAxis(m_TurnAxisName);  
    }

    private void FixedUpdate(){
        Move();
        Turn();
    }
    //forward backwards
    private void Move(){
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement); 
    }

    private void Turn(){

        Vector3 movement2 = transform.right * m_TurnInputValue * m_Speed * Time.deltaTime;
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement2); 

        /*
         float turn = m_TurnInputValue *m_TurnSpeed * Time.deltaTime;

         Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

         m_Rigidbody.MoveRotation (m_Rigidbody.rotation * turnRotation);
         */
    }

}
