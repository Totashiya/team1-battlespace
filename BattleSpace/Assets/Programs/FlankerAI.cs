using System;
using UnityEngine;
using System.Collections;

public class FlankerAI : MonoBehaviour {

	public float m_MoveRate;
	public float m_FireRate;
	public int m_BurstNumber;
	public Rigidbody m_Shell;
	public Transform m_FireTransform;
	public int m_LaunchForce;
	public float scalefactor;
	public Rigidbody m_Self;

	private float m_targetfiretime;
	private int m_position;

	private Vector3 m_relativelocation;

	private int m_prevFlankerNumber;
	private int m_direction;
	private string m_MovementAxisName;     
	private string m_YawAxisName;
	private float m_MovementInputValue;    
	private float m_YawInputValue;
	// Use this for initialization
	void Start () {
		m_targetfiretime = 0f;
		m_MovementAxisName = "Thrust";
		m_YawAxisName = "Yaw";

		m_Self.MovePosition (m_relativelocation);
	}
	
	// Update is called once per frame
	void Update () {
		m_MovementInputValue = Input.GetAxis (m_MovementAxisName);
		m_YawInputValue = Input.GetAxis (m_YawAxisName);
	}
	private IEnumerator FireBurst(){
		for (int i = 0; i < m_BurstNumber; i++ ) {
			m_targetfiretime = Time.time + m_FireRate;
			while (Time.time < m_targetfiretime) {
				yield return null;
			}
			Fire ();
		}

		yield break;
	}

	public void Fire()
	{
		Rigidbody shellInstance = Instantiate (m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
		shellInstance.velocity = m_LaunchForce* m_FireTransform.forward;

	}
	private void Move()
	{
		// Adjust the position of the tank based on the player's input.
		Vector3 vmovement = transform.up *-m_MovementInputValue *m_MoveRate *Time.deltaTime;

		// Adjust the position of the tank based on the player's input.
		Vector3 hmovement = transform.right * -m_YawInputValue *m_MoveRate *Time.deltaTime;


		// Apply this movement to the rigidbody's position
		m_Self.MovePosition (m_Self.position + vmovement+ hmovement);
	}
	public void BurstFire(){
		StartCoroutine (FireBurst ());
	}
}
