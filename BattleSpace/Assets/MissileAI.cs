﻿using UnityEngine;
using System.Collections;

public class MissileAI : MonoBehaviour {
	public float m_FireRate;
	public float m_MoveRate;
	public Rigidbody m_Self;
	public Rigidbody m_Shell;
	public Transform m_FireTransform;
	public int m_CurrentLaunchForce;
	public ParticleSystem EnemyExplosion;

    public float stopPosition = -3;

	private float m_TotalFireTime;
	private bool m_FireFlag;

	// Use this for initialization
	void Start () {
        
		m_TotalFireTime = Time.time + m_FireRate;
		Vector3 DownwardForce = new Vector3 (0f, 0f, m_MoveRate);
		m_Self.AddForce (DownwardForce);
		m_FireFlag = false;
	}

    IEnumerator IgnoreMisslesSelf() {
        print("Ignore collisions with own missles");
        Physics.IgnoreLayerCollision(8, 11, true);
        yield return new WaitForSeconds(2);
        Physics.IgnoreLayerCollision(8, 11, false);
    }

    Rigidbody shellInstance;

	// Update is called once per frame
	void Update () {
        /*if(gameObject.transform.position.z >= stopPosition) {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }*/
		if (Time.time >= m_TotalFireTime) {
			m_FireFlag = true;
			m_TotalFireTime = Time.time + m_FireRate;
		}
		if (m_FireFlag == true) {
			shellInstance = Instantiate (m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
            StartCoroutine(IgnoreMisslesSelf()); // temporarily disable collisions with missles so the enemy doesn't kill itself instantly
            shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.up;
			m_FireFlag = false;
        }
	}
}
