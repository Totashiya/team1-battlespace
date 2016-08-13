using System;
using UnityEngine;
using System.Collections;

public class FlankerAI : MonoBehaviour {


	public float m_FireRate;
	public int m_BurstNumber;
	public Rigidbody m_Shell;
	public Transform m_FireTransform;
	public int m_LaunchForce;
	public Rigidbody m_Self;
	public float m_moveRate;

	private float m_targetfiretime;
	private float m_targetfiretime2;
	private Transform m_Player;

	// private Vector3 m_relativelocation; //** commented out to remove warning


	void Start () {
		m_targetfiretime = 0f;

		try{
		m_Player = GameObject.Find ("PlayerCapsule(Clone)").transform;
		}
		catch{
		}

		m_targetfiretime2 = Time.time + m_FireRate;

		// m_Self.MovePosition (m_relativelocation);
	}
	
	// Update is called once per frame
	void Update () {
		try {
			transform.LookAt (m_Player);
		}
		catch{
		}
		if (Time.time > m_targetfiretime2) {
			BurstFire ();
			m_targetfiretime2 = Time.time + m_FireRate;
		}
		Vector3 DownwardForce = new Vector3 (0f, 0f, m_moveRate*Time.deltaTime);
		m_Self.MovePosition (m_Self.position + DownwardForce);
	}
	private IEnumerator FireBurst(){
		for (int i = 0; i < m_BurstNumber; i++ ) {
			m_targetfiretime = Time.time + 0.2f;
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
	public void BurstFire(){
		StartCoroutine (FireBurst ());
	}
}
