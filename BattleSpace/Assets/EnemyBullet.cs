using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {

	public float m_Speed;
	public int m_Damage = 10; // how much damage the bullet does to the player

	public GameObject hitExplosion;

	bool isColliding = false; // boolean to prevent multiple simultaneous collisions

	void Start () {
		GetComponent<AudioSource>().Play();
	}

	// Update is called once per frame
	void Update () {
		isColliding = false;

	}
	void OnTriggerEnter(Collider other) {
		PlayerHealth playerHealth = GameObject.Find("GameManager").GetComponent<PlayerHealth>();

		if (isColliding) return;

		else if (other.CompareTag("Player")) {
			isColliding = true;
			playerHealth.takeDamage(m_Damage);
			GameObject HitExplosion = Instantiate(hitExplosion, gameObject.transform.position, gameObject.transform.rotation) as GameObject;

			GetComponent<MeshRenderer>().enabled = false;
			transform.position = new Vector3(1000, 0, 0);

			other.gameObject.GetComponent<AudioSource>().Play();

			Destroy(gameObject, GetComponent<AudioSource>().clip.length);
			Destroy(HitExplosion, HitExplosion.GetComponent<ParticleSystem>().duration);
		}
	}
}
