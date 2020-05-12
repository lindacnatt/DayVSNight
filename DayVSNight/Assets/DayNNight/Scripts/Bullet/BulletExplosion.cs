using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
{
    public LayerMask m_PlayerMask;
    public ParticleSystem m_ExplosionParticles;
    public float m_MaxDamage = 100f;
    public float m_ExplosionForce = 1000f;
    public float m_MaxLifeTime = 2f;
    public float m_ExplosionRadius = 10f;
    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, m_MaxLifeTime);
    }
    private void onTriggerEnter(Collider other){
        Collider[] colliders = Physics.OverlapSphere (transform.position, m_ExplosionRadius, m_PlayerMask);

        for (int i = 0; i < colliders.Length; i++){
            
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>(); // Find a rigidbody
            Debug.Log("HIT BODY");
            if(!targetRigidbody)
                continue;
                 
            targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);

            PlayerHealth targetHealth = targetRigidbody.GetComponent<PlayerHealth>();
            
            if(!targetHealth)
                continue;
            
            float damage = CalculateDamage(targetRigidbody.position);   

            targetHealth.TakeDamage(damage);
        }
        m_ExplosionParticles.transform.parent = null;
        m_ExplosionParticles.Play();
         Debug.Log("explode");

       // Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.main.duration);
        Destroy(gameObject);

    }

    private float CalculateDamage(Vector3 targetPosition){
        Vector3 explosionToTarget = targetPosition - transform.position;

        float explosionDistance = explosionToTarget.magnitude;

        float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;

        float damage = relativeDistance * m_MaxDamage;

        damage = Mathf.Max(0f, damage);
        
        return damage;
    }
}
