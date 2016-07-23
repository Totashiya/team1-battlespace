using UnityEngine;
using System.Collections;

public class Hits : MonoBehaviour {

	public GameObject self;
	public Rigidbody selfr;
	public int firerate;
	public Rigidbody m_Shell;
	public Transform m_FireTransform;
	public int m_CurrentLaunchForce;
	public int EnemySpeed;

	private float time;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Adjust the position of the tank based on the player's input.


		// Adjust the position of the tank based on the player's input.
		Vector3 hmovement = transform.right * Random.Range(-1,1) *EnemySpeed *Time.deltaTime;


		// Apply this movement to the rigidbody's position
		selfr.MovePosition (selfr.position + hmovement);
		if (time % firerate < 0.1) {
			Fire ();
		}
		time += Time.deltaTime;

	}

	void OnTriggerEnter (){
		Destroy (self);
		}
	private void Fire(){
	// Instantiate and launch the shell.
		Rigidbody shellInstance = Instantiate (m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
		shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.up;;

	}
}