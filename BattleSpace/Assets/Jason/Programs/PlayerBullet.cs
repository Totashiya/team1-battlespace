using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {

    bool isColliding = false; // boolean to prevent multiple simultaneous collisions

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        isColliding = false;	
	}

	void OnTriggerEnter(Collider other) {
        PlayerScore playerScore = GameObject.Find("GameManager").GetComponent<PlayerScore>();
        if (isColliding) return;
        else if (other.CompareTag("Enemies")) {
            isColliding = true;
            Debug.Log("Hit an enemy");
            playerScore.AddScore(100);
            Destroy(other.gameObject);
        }
	}
}
