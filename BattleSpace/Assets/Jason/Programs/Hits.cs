﻿using UnityEngine;
using System.Collections;

public class Hits : MonoBehaviour {

	public GameObject self;
	public BoxCollider Box1;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Box1.isTrigger == true) {
			Destroy (self);
		}
	}
}