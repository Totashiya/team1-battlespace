using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HomingBullet : MonoBehaviour {

    public float m_MinSpeed = 2;
    public float m_MaxSpeed = 5;
    public float m_AccelRate = 0.02f;
    public int m_Damage = 30; // how much damage the bullet does to the player
    Rigidbody m_Self;
    public GameObject hitExplosion;
    public GameObject Follow;
    public Vector3 CompVector;

    bool isColliding = false; // boolean to prevent multiple simultaneous collisions
    private Transform m_Player;
    private float m_Speed;

    bool StopFollowing;
    bool follow = true;

    void Start() {
        StopFollowing = false;
        m_Speed = m_MinSpeed;
        GetComponent<AudioSource>().Play();
		try{
        m_Player = GameObject.Find("PlayerCapsule(Clone)").transform;
		}
		catch{
		}
    }

    void Update() {
        StopFollowing = GetComponent<BulletDisappear>().DestroyFlag;
        if (StopFollowing) {
            follow = false;
        }
    }

    void FixedUpdate() {
        isColliding = false;
		float step = Time.deltaTime * m_Speed;
		try {
			m_Player = GameObject.Find("PlayerCapsule(Clone)").transform;

	        if (follow) {
	            transform.position = Vector3.MoveTowards(transform.position, m_Player.transform.position, step);
	            transform.LookAt(m_Player.position);
	            transform.Rotate(CompVector);
	        }
	        else {
	            print("Stopped following");
	            transform.position = Vector3.MoveTowards(transform.position, Follow.transform.position, step);
	        }

	        if (m_Speed < m_MaxSpeed) {
	            m_Speed += m_AccelRate;
	        }
		}

		catch {
			print ("Could not find player, moving forward");
			transform.position = Vector3.MoveTowards(transform.position, Follow.transform.position, step);
		}
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
            transform.localScale = new Vector3(0, 0, 0);

            other.gameObject.GetComponent<AudioSource>().Play();

            Destroy(gameObject, GetComponent<AudioSource>().clip.length);
            Destroy(HitExplosion, HitExplosion.GetComponent<ParticleSystem>().duration);
        }

        else if (other.CompareTag("Enemies")) {
            print("Missle hit enemy");
            isColliding = true;

            GameObject HitExplosion = Instantiate(hitExplosion, gameObject.transform.position, gameObject.transform.rotation) as GameObject;

            GetComponent<MeshRenderer>().enabled = false;
            transform.position = new Vector3(1000, 0, 0);
            transform.localScale = new Vector3(0, 0, 0);

            GetComponent<AudioSource>().Play();

            Destroy(other.gameObject);
            Destroy(gameObject, GetComponent<AudioSource>().clip.length + 0.2f);
            Destroy(HitExplosion, HitExplosion.GetComponent<ParticleSystem>().duration);
        }
    }
}