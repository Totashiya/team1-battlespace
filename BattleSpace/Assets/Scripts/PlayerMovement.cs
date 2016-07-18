using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float speed = 0.05f;
    public float rotationSpeed = 150f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Move();	// The ship will move forward at all times.
        Rotate(); // The player will control the rotation of the ship
	}

    void Move() {
        transform.Translate(0, 0, speed);
    }

    void Rotate() {
        float rotation = Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);
    }
}
