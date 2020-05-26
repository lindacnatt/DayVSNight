using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
    public DayNightCycle Sun;
    public DayNightCycle Moon;
    public bool Player;
    public List<PlayerHealth> Enemies;
    public bool Dead;
    public GameObject endCam;
    public EndGUI end;
    private int enemiesDead=0;
    private int allEnemies;


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
        allEnemies = Enemies.Count;

        if (PlayerPrefs.GetFloat("TopScore")==null)
        {
            PlayerPrefs.SetFloat("TopScore", 0);
        }

        
        PlayerPrefs.SetFloat("PlayerScore", 0);
       
    }


    private void OnEnable(){
        m_CurrentHealth = m_StartingHealth;
        m_Dead = false;
        Dead = false;
        Score.text = "100/" + Mathf.RoundToInt(m_CurrentHealth);

        SetHealthUI();
        Debug.Log("I have full health" + m_CurrentHealth);
    }

    public void TakeDamage(float amount){
        m_CurrentHealth -= amount;
        if (Player)
        {
            Sun.SunHit(10);
            Moon.SunHit(10);       // Toggles the sun/moon to go through one step of the day night cycle
        }
        if (!Player) 
        {
            Sun.MoonHit(2);
            Moon.MoonHit(2);

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
        //affects the appearence of the health bar, changes the value and the color
        m_Slider.value = m_CurrentHealth;
        m_FillImage.color = Color.Lerp(m_ZeroHealthColor,m_FullHealthColor, m_CurrentHealth / m_StartingHealth);
    }

    private void onDeath(){
        m_Dead = true;
        Dead = true;
        foreach (PlayerHealth Enemy in Enemies)
        {
            if (Enemy.Dead)
            {
                enemiesDead += 1;
                Debug.Log("Enemy dead" + enemiesDead);
            }
        }
        //Explode when dead
        m_ExplosionParticles.transform.position = transform.position;
        m_ExplosionParticles.gameObject.SetActive(true);

        m_ExplosionParticles.Play();
        //End game
        gameObject.SetActive(false);
       
       
        if (Player || (enemiesDead == allEnemies))
        {


            float playerTime = Time.time;
            float highScore = PlayerPrefs.GetFloat("TopScore");
      
            if (playerTime < highScore)
            {
                PlayerPrefs.SetFloat("TopScore", playerTime);
                highScore = PlayerPrefs.GetFloat("TopScore");
            }
            PlayerPrefs.SetFloat("PlayerScore", playerTime);

            PlayerPrefs.Save();

            

            endCam.SetActive(true);
            
            Debug.Log("End screen activated");
        }
       
    }
}


