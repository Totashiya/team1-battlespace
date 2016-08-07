using UnityEngine;
using System.Collections;

public class HomingBullet : MonoBehaviour {



	public Rigidbody m_Player;
	public float m_Speed;

	float m_PlayerHealth;

	void Start () {
		//playerHealth = gameManager.GetComponent (PlayerHealth).m_CurrentHealth;
	}
	
	// Update is called once per frame
	void Update () {
		/*
		float m_Step = m_Speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position,m_Player.position, m_Speed);
		transform.LookAt (m_Player.position);
		*/

	}
}
