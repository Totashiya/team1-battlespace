using UnityEngine;
using System.Collections;

public class HomingBullet : MonoBehaviour {

    public float m_MinSpeed = 2;
    public float m_MaxSpeed = 5;
    public float m_AccelRate = 0.02f;
    public int m_Damage = 30; // how much damage the bullet does to the player
	Rigidbody m_Self;
    public GameObject hitExplosion;
	public Vector3 CompVector;

    bool isColliding = false; // boolean to prevent multiple simultaneous collisions
	private Transform m_Player;
    private float m_Speed;

    bool StopFollowing;
    bool follow = true;

	void Start () {
        StopFollowing = false;
        m_Speed = m_MinSpeed;
        GetComponent<AudioSource>().Play();

		m_Player = GameObject.Find("PlayerCapsule(Clone)").transform;
	}
	
    void Update() {
        StopFollowing = GetComponent<BulletDisappear>().DestroyFlag;
        if(StopFollowing) {
            follow = false;
        }
    }

	void FixedUpdate () {
        isColliding = false;
		m_Player = GameObject.Find("PlayerCapsule(Clone)").transform;

		float step = Time.deltaTime * m_Speed;

        if (follow) {
            transform.position = Vector3.MoveTowards(transform.position, m_Player.transform.position, step);
            transform.LookAt(m_Player.position);
            transform.Rotate(CompVector);
        }
        else {
            print("Stopped following");
            transform.Translate(transform.position * Time.deltaTime * m_Speed, Space.World);
        }

        if(m_Speed < m_MaxSpeed) {
            m_Speed += m_AccelRate;
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

            other.gameObject.GetComponent<AudioSource>().Play();

            Destroy(gameObject, GetComponent<AudioSource>().clip.length);
            Destroy(HitExplosion, HitExplosion.GetComponent<ParticleSystem>().duration);
        }
    }
}
