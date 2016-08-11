using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[Serializable]
public class BasicManager: MonoBehaviour{

	public float m_FireRate;
	public float m_MoveRate;
	public Rigidbody m_Self;
	public Rigidbody m_Shell;
	public Transform m_FireTransform;
	public int m_CurrentLaunchForce;
    public ParticleSystem EnemyExplosion;

	private float m_TotalFireTime;
	private bool m_FireFlag;

	// Use this for initialization
	void Start () {
		m_TotalFireTime = Time.time + m_FireRate;
		Vector3 DownwardForce = new Vector3 (0f, 0f, m_MoveRate);
		m_Self.AddForce (DownwardForce);
		m_FireFlag = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= m_TotalFireTime) {
			m_FireFlag = true;
			m_TotalFireTime = Time.time + m_FireRate;
		}
		if (m_FireFlag == true) {
			Rigidbody shellInstance = Instantiate (m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
			shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.up;
			m_FireFlag = false;
		}
	}
}

