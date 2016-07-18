using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float horizontalSpeed = 5f; // speed of ship moving left and right
	public float rotateSpeed = 20f;
	public float forwardSpeed = 10f;
	public float backwardSpeed = -8f;
	public float decelerationAmount = 0.9f; // bigger value increases deceleration speed

	Rigidbody playerRigidbody;

	Vector3 movement;

	void Start () {
		playerRigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		float horizontal = Input.GetAxisRaw("Horizontal"); 
		float vertical = Input.GetAxisRaw ("Vertical");

		Move(horizontal, vertical);	// WASD to move
        Aim(); // Mouse to aim and rotate the ship
	}

	void Move(float h, float v) {
		movement.Set (h, 0, 0);
		movement *= horizontalSpeed * Time.deltaTime;

		if (h == 1) {
			playerRigidbody.rotation = Quaternion.Lerp(playerRigidbody.rotation, Quaternion.Euler (0, 0, -20), rotateSpeed * Time.deltaTime);
		}
		else if (h == -1) {
			playerRigidbody.rotation = Quaternion.Lerp(playerRigidbody.rotation, Quaternion.Euler (0, 0, 20), rotateSpeed * Time.deltaTime);
		}
		else {
			playerRigidbody.rotation = Quaternion.Lerp (playerRigidbody.rotation, Quaternion.identity, rotateSpeed * Time.deltaTime);
		}
		
		playerRigidbody.MovePosition (transform.position + movement);

		if(v == 1) {
			// If W or up is pressed, move forward
			playerRigidbody.AddForce (transform.forward * forwardSpeed);
		}
		else if (v == -1) {
			// If S or down is pressed, move back
			playerRigidbody.AddForce (transform.forward * backwardSpeed);
		}
    }

    void Aim() {
		// player turns the ship and aims using the mouse
    }
}
