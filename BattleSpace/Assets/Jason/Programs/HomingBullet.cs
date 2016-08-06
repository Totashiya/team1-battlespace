using UnityEngine;
using System.Collections;

public class HomingBullet : MonoBehaviour {

	public Rigidbody m_Player;
	public float m_Speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	/*void Update () {
		float m_Step = m_Speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position,m_Player.position, m_Speed);
		transform.LookAt (m_Player.position);
	}*/
}
