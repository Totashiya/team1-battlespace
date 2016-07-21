using UnityEngine;
using System.Collections;

public class BulletDissappear : MonoBehaviour {

	public float waittime;
	public GameObject m_Rigidbody;

	private bool DestroyFlag;
	// Use this for initialization
	void Start () {
		StartCoroutine (SelfDestruct ());
		DestroyFlag = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (DestroyFlag == true) {
			Destroy (m_Rigidbody);
		}
	}

	IEnumerator SelfDestruct(){
		yield return new WaitForSeconds (waittime);
	}
	void OnTriggerEnter(){
		DestroyFlag = true;
	}
}
