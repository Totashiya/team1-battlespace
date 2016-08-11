using UnityEngine;
using System.Collections;

public class PlayerParticles : MonoBehaviour {

    public GameObject m_LeftThrusterParticles;
    public GameObject m_RightThrusterParticles;
    public GameObject m_DamagedParticles;

    ParticleSystem leftThruster;
    ParticleSystem rightThruster;

    float m_CurrentHealth;
    float m_DamagedHealth;

    bool m_isForward;
    bool m_isReverse;

	void Start () {
        m_LeftThrusterParticles.SetActive(true);
        leftThruster = m_LeftThrusterParticles.GetComponent<ParticleSystem>();

        m_RightThrusterParticles.SetActive(true);
        rightThruster = m_RightThrusterParticles.GetComponent<ParticleSystem>();

        m_DamagedParticles.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        PlayerHealth playerHealth = GameObject.Find("GameManager").GetComponent<PlayerHealth>();

        m_isReverse = gameObject.GetComponent<PlayerMovement>().isReverse;

        m_CurrentHealth = playerHealth.m_CurrentHealth;
        m_DamagedHealth = playerHealth.m_LowHealth;

        if(m_CurrentHealth <= m_DamagedHealth) {
            m_DamagedParticles.SetActive(true);
        }
        else {
            m_DamagedParticles.SetActive(false);
        }

        var em_leftThruster = leftThruster.emission;
        var em_rightThruster = rightThruster.emission;

        em_leftThruster.enabled = !m_isReverse;
        em_rightThruster.enabled = !m_isReverse;
	}
}
