using UnityEngine;
using System.Collections;

public class Player_Firing : MonoBehaviour {

	public int m_PlayerNumber = 1;       
	public Rigidbody m_Shell;
	public Rigidbody m_Player;
	public Transform m_FireTransform;
    public float fireRate = 0.2f;
	public float m_LaunchForce = 30f; 
	public float m_MaxChargeTime = 0.75f;

	private string m_FireButton;         
	private float m_CurrentLaunchForce;       
	private bool m_Fired;
    private float lastShot = 0f; 


	private void OnEnable()
	{
		m_CurrentLaunchForce = m_LaunchForce;
	}


	private void Start()
	{
		m_FireButton = "Fire" + m_PlayerNumber;
	}


	private void Update()
	{
		// Track the current state of the fire button and make decisions based on the current launch force.
        /*
		if (Input.GetButtonDown (m_FireButton)) 
		{
			m_Fired = false;
			m_CurrentLaunchForce = m_LaunchForce;
		}
			
		else if (Input.GetButtonUp (m_FireButton) && !m_Fired)
		{
			Fire ();
		}
        */

        if(Input.GetButton(m_FireButton)) {
            if(Time.time > fireRate + lastShot) {
                Fire();
            }
        }
	}


	void Fire()
	{
		// Instantiate and launch the shell.
		Rigidbody shellInstance = Instantiate (m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
		shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.up;
        lastShot = Time.time;
        //m_CurrentLaunchForce = m_LaunchForce;
	}
}
