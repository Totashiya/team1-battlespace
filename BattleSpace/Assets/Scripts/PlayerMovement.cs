using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float m_moveSpeed = 5f;          // How fast the player can move
    public float m_forwardSpeed = 0.1f;       // How fast the player is moving forward (make this a small value; we need this only to create a sense of movement

    Rigidbody m_Rigidbody;

    Vector3 movement;

	void Start () {
        m_Rigidbody = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


		m_Rigidbody.Sleep ();
        Move(horizontal, vertical);
	}

    void Move(float h, float v) {
        movement.Set(h, 0, v);
        movement = movement.normalized * m_moveSpeed * Time.deltaTime;

        m_Rigidbody.MovePosition(transform.position + movement);
    }
}
