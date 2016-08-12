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

	private float m_targetfiretime;
	private Transform m_Player;

	// private Vector3 m_relativelocation; //** commented out to remove warning


	void Start () {
		m_targetfiretime = Time.time + m_FireRate;
		try{
		m_Player = GameObject.Find ("PlayerCapsule(Clone)").transform;
		}
		catch{
		}

		// m_Self.MovePosition (m_relativelocation);
	}
	
	// Update is called once per frame
	void Update () {
		try {
			transform.LookAt (m_Player);
		}
		catch{
		}
		if (Time.time > m_targetfiretime) {
			BurstFire ();
			m_targetfiretime = Time.time + m_targetfiretime;
		}
		if (transform.position.y > 0) {
			m_Self.Sleep ();
		}
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
	public void BurstFire(){
		StartCoroutine (FireBurst ());
	}
}
