using UnityEngine;
using System.Collections;

public class Hits : MonoBehaviour {

	public GameObject self;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (){
		Destroy (self);     
	}
}