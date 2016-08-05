using UnityEngine;
using System.Collections;

public class HitShield : MonoBehaviour {

	public GameObject self;
	public int HitsEndured;
	// Use this for initialization

	private int hits;
	void Start () {
		hits = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (hits >= HitsEndured) {
			Destroy (self);
		}
	}
	void OnTriggerEnter(){
		hits++;
	}
}
