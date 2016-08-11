using UnityEngine;
using System.Collections;

public class PlayerParticles : MonoBehaviour {

    public GameObject m_EngineParticles;
    public GameObject m_DamagedParticles;

    ParticleSystem engine;

    float m_CurrentHealth;
    float m_DamagedHealth;

    bool m_isForward;
    bool m_isReverse;

	void Start () {
        m_EngineParticles.SetActive(true);
        engine = m_EngineParticles.GetComponent<ParticleSystem>();

        m_DamagedParticles.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        PlayerHealth playerHealth = GameObject.Find("GameManager").GetComponent<PlayerHealth>();
        m_isForward = gameObject.GetComponent<PlayerMovement>().isForward;
        m_isReverse = gameObject.GetComponent<PlayerMovement>().isReverse;

        m_CurrentHealth = playerHealth.m_CurrentHealth;
        m_DamagedHealth = playerHealth.m_LowHealth;

        if(m_CurrentHealth <= m_DamagedHealth) {
            m_DamagedParticles.SetActive(true);
        }
        else {
            m_DamagedParticles.SetActive(false);
        }

        var em_engine = engine.emission;

        em_engine.enabled = !m_isReverse && m_isForward;
	}
}
