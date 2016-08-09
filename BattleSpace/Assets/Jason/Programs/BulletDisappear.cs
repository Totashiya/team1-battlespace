using UnityEngine;
using System.Collections;

public class BulletDisappear : MonoBehaviour {

	public float destroy;

	private bool DestroyFlag;
	private float target;
	// Use this for initialization
	void Start () {
		DestroyFlag = false;
		target = Time.time + destroy;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > target) {
			DestroyFlag = true;
		}
		if (DestroyFlag == true) {
			Destroy (gameObject);
		}

	}

	void OnTriggerEnter(Collider other){
		DestroyFlag = true;
	}
}
