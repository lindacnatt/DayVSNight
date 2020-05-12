using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int m_PlayerNumber = 1;
    public float m_Speed = 12f;

    private string m_MovementForward; //vertical axis 
    private string m_MovementSide; //horizontal axis
    
    private Rigidbody m_Rigidbody;
    private float m_ForwardInputValue;
    private float m_SideInputValue;

    private void Awake(){
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable(){
        m_Rigidbody.isKinematic = false;
        m_ForwardInputValue = 0f;
        m_SideInputValue = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_MovementForward = "Vertical" + m_PlayerNumber;
        m_MovementSide = "Horizontal" + m_PlayerNumber; 
    }

    // Update is called once per frame
    void Update()
    {
        m_ForwardInputValue = Input.GetAxis(m_MovementForward);
        m_SideInputValue = Input.GetAxis(m_MovementSide);  
    }

    private void FixedUpdate(){
        MoveForward();
        MoveSideways();
    }
    //forward backwards
    private void MoveForward(){
        Vector3 movementFront = transform.forward * m_ForwardInputValue * m_Speed * Time.deltaTime;
        m_Rigidbody.MovePosition(m_Rigidbody.position + movementFront); 
    }

    private void MoveSideways(){

        Vector3 movementSide = transform.right * m_SideInputValue * m_Speed * Time.deltaTime;
        m_Rigidbody.MovePosition(m_Rigidbody.position + movementSide); 
    }

}
