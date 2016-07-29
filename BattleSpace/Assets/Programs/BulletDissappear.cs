using UnityEngine;
using System.Collections;

public class BulletDissappear : MonoBehaviour {

	public float destroy;
	public GameObject m_Rigidbody;

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
			Destroy (m_Rigidbody);
		}
	}


	void OnTriggerEnter(){
		DestroyFlag = true;
	}
}
