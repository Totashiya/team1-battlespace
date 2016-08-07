using UnityEngine;
using System.Collections;

public class HomingBullet : MonoBehaviour {

	public Rigidbody m_Player;
	public float m_Speed;
    public int m_Damage = 10; // how much damage the bullet does to the player

	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		/*
		float m_Step = m_Speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position,m_Player.position, m_Speed);
		transform.LookAt (m_Player.position);
		*/
	}
    void OnTriggerEnter(Collider other) {
        PlayerHealth playerHealth = GameObject.Find("GameManager").GetComponent<PlayerHealth>();

        if (other.CompareTag("Player")) {
            playerHealth.takeDamage(m_Damage);
        }
    }
}
