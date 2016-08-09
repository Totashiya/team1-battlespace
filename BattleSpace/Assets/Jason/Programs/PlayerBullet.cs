using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerBullet : MonoBehaviour {

	// The player will earn more points the closer the enemy is to the bottom of the screen.
	// This will discourage spamming down a lane while rewarding difficult kills
	public int minEarned = 50;
	public int maxEarned = 1000;

    bool isColliding = false; // boolean to prevent multiple simultaneous collisions

	int earned;

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
            //Debug.Log("Hit an enemy");

			float enemyVPosition = other.transform.position.z;
			// print ("Enemy killed at position(Z) " + enemyVPosition.ToString ());

			float t = map (enemyVPosition, -14, 12, 0, 1);
			// print ("PlayerBullet: Ratio is " + t.ToString());

			earned = (int) Mathf.Lerp (minEarned, maxEarned, t);
			// print ("Player earns " + earned.ToString());

            playerScore.AddScore(earned);
            Destroy(other.gameObject);


        }
	}

	float map(float value, float low1, float high1, float low2, float high2) {
		return (low2 + (value - low1) * (high2 - low2) / (high1 - low1));
	}
}
