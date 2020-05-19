using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public DayNightCycle Sun;
    public DayNightCycle Moon;
    public bool Player;
    public List<GameObject> Enemies;
    private EndGUI end;

    public float m_StartingHealth = 100f;
    public Slider m_Slider;
    public Image m_FillImage;
    public Text Score;
    public Color m_FullHealthColor = Color.green;
    public Color m_ZeroHealthColor = Color.red;


    public GameObject m_ExplosionPrefab;
    private ParticleSystem m_ExplosionParticles;  
    private float m_CurrentHealth;
    private bool m_Dead;

    private void Awake()
    {
        m_ExplosionParticles = Instantiate(m_ExplosionPrefab).GetComponent<ParticleSystem>();
        m_ExplosionParticles.gameObject.SetActive(false);
    }


    private void OnEnable(){
        m_CurrentHealth = m_StartingHealth;
        m_Dead = false;
        Score.text = "100/" + Mathf.RoundToInt(m_CurrentHealth);

        SetHealthUI();
        Debug.Log("I have full health" + m_CurrentHealth);
    }

    public void TakeDamage(float amount){
        m_CurrentHealth -= amount;
        if (Player)
        {
            Sun.SunHit(amount);
            Moon.SunHit(amount);       // Toggles the sun/moon to go through one step of the day night cycle
        }
        if (!Player)
        {
            Sun.MoonHit(amount);
            Moon.MoonHit(amount);

        }

        if (m_CurrentHealth <= 0f && !m_Dead)
        {
            onDeath();
            Score.text = "Dead";
           
        }
        else if (m_CurrentHealth > 0f){
        Score.text = "100/" + Mathf.RoundToInt(m_CurrentHealth);
        }

        SetHealthUI();
       
        
    }

    private void SetHealthUI(){
        m_Slider.value = m_CurrentHealth;
        m_FillImage.color = Color.Lerp(m_ZeroHealthColor,m_FullHealthColor, m_CurrentHealth / m_StartingHealth);
    }

    private void onDeath(){
        m_Dead = true;

        m_ExplosionParticles.transform.position = transform.position;
        m_ExplosionParticles.gameObject.SetActive(true);

        m_ExplosionParticles.Play();
        //End game
        gameObject.SetActive(false);
        if (Player)
        {
           end.sunwinner = true;
           SceneManager.LoadScene("EndScreen");
        }
       
    }
}
