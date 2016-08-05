using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour {

	public GameObject orbitObject;		// object to orbit around

	public float orbitSpeed = 20f;		// speed at which the camera will orbit

	public Vector3 orbitAxis = new Vector3(1f, 0.5f, 0f);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (orbitObject.transform.position, orbitAxis, orbitSpeed * Time.deltaTime);
	}
}
