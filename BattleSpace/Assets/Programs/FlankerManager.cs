using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class FlankerManager : MonoBehaviour{
	public Rigidbody m_Player;
	public float m_FireRate;
	public float m_Turnrate;
	public int m_BurstNumber;
	public Rigidbody m_Shell;
	public Transform m_FireTransform;
	public int m_LaunchForce;
	public float scalefactor;
	[HideInInspector] public int m_FlankerNumber;
	[HideInInspector] public int m_TotalFlankers;
	[HideInInspector] public bool m_FireSignal;
	public Rigidbody m_Self;
	[HideInInspector] public GameObject m_Instance;

	private float m_targetfiretime;
	private int m_position;
	private float m_degrees;
	private Vector3 m_relativelocation;
	private float m_xlocation;
	private float m_ylocation;
	private int m_prevFlankerNumber;
	private int m_direction;
	// Use this for initialization
	void Start () {
		m_targetfiretime = 0f;
		m_degrees = 0f;
		m_position = m_FlankerNumber % 2;
		StartCoroutine (Turn ());
		switch (m_TotalFlankers) {
		case 1:
			m_xlocation = 0.5f;
			m_ylocation = 1f;
			break;
		case 2:
			if (m_FlankerNumber == 1) {
				m_xlocation = 0.25f;
			} else {
				m_xlocation = 0.75f;
			}
			m_ylocation = 0.75f;
			break;
		case 3:
			switch (m_FlankerNumber) {
			case 1:
				m_xlocation = 0.25f;
				m_ylocation = 0.75f;
				break;
			case 2:
				m_xlocation = 0.5f;
				m_ylocation = 1.0f;
				break;
			case 3:
				m_xlocation = 0.75f;
				m_ylocation = 0.75f;
				break;
			}
			break;
		}
		m_relativelocation = new Vector3 (m_Player.position.x + m_ylocation*scalefactor,0f,m_Player.position.z + m_xlocation*scalefactor);
	}
	
	// Update is called once per frame
	void Update () {
		if (m_FireSignal == true) {
			StartCoroutine (FireBurst ());
			if (m_position == 1) {
				m_degrees += 60;
			} else if (m_position == 0) {
				m_degrees -= 60;
			}
			m_FireSignal = false;
		}
		if (m_degrees > 0) {
			m_direction = 1;
		} else if (m_degrees < 0) {
			m_direction = -1;
		}
		if (m_prevFlankerNumber != m_FlankerNumber) {
			switch (m_TotalFlankers) {
			case 1:
				m_xlocation = 0.5f;
				m_ylocation = 1f;
				break;
			case 2:
				if (m_FlankerNumber == 1) {
					m_xlocation = 0.33f;
				} else {
					m_xlocation = 0.66f;
				}
				m_ylocation = 0.75f;
				break;
			case 3:
				switch (m_FlankerNumber) {
				case 1:
					m_xlocation = 0.25f;
					m_ylocation = 0.75f;
					break;
				case 2:
					m_xlocation = 0.5f;
					m_ylocation = 1.0f;
					break;
				case 3:
					m_xlocation = 0.75f;
					m_ylocation = 0.75f;
					break;
				}
				break;
			}
		}
		m_prevFlankerNumber = m_TotalFlankers;
		m_relativelocation = new Vector3 (m_Player.position.x + m_ylocation*scalefactor,0f,m_Player.position.z + m_xlocation*scalefactor);
		m_Self.MovePosition (m_Self.position + m_relativelocation);
		m_Self.Sleep ();

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
	private IEnumerator Turn(){
		float turn = 1f * m_Turnrate * Time.deltaTime;
		Quaternion turnRotation = Quaternion.Euler (0f,(turn * m_direction), 0f);
		float aggturn = turn;
		while (aggturn != m_degrees) {
			aggturn += turn;
			if (aggturn > Mathf.Abs (m_degrees)) {
				break;
			}
			m_Self.MoveRotation (m_Self.rotation * turnRotation);
			yield return null;
		}
		float remainder = Mathf.Abs (m_degrees) - (aggturn - turn);
		turnRotation = Quaternion.Euler (0f, remainder * m_direction, 0f);
		m_Self.MoveRotation (m_Self.rotation * turnRotation);
		m_degrees = Mathf.Abs (m_degrees - 1f);
		yield break;
	}
	void Fire()
	{
		Rigidbody shellInstance = Instantiate (m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
		shellInstance.velocity = m_LaunchForce* -m_FireTransform.up;

	}
}
