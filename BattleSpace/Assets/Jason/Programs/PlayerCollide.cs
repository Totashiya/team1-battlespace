using UnityEngine;
using System.Collections;

public class PlayerCollide : MonoBehaviour {

	public GameObject GameManager;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		GameManager.GetComponent<PlayerHealth>().takeDamage ();
	}
}
