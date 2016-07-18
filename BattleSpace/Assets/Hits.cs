using UnityEngine;
using System.Collections;

public class Hits : MonoBehaviour {

	private int hits = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter (){
		print ("Hit!");
		hits += 1;
		print (hits/4);
		if (hits % 100 == 0) {
			Debug.ClearDeveloperConsole ();
		}
	}
}
