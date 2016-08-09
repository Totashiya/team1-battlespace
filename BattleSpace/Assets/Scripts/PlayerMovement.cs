using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float m_moveSpeed = 5f;          // How fast the player can move
	public float leftBorder = 0.03f;
	public float rightBorder = 0.97f;
	public float topBorder = 0.9f;
	public float botBorder = 0.1f;

    Rigidbody m_Rigidbody;

    Vector3 movement;

	void Start () {
        m_Rigidbody = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Move(horizontal, vertical);


		/*
		pos.x = Mathf.Clamp (pos.x, 0.03f, 0.97f);

		transform.position = Camera.main.ViewportToWorldPoint (pos);
*/

	}

    void Move(float h, float v) {
		Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
		pos.x = Mathf.Clamp (pos.x, leftBorder, rightBorder);
		pos.y = Mathf.Clamp (pos.y, botBorder, topBorder);
		transform.position = Camera.main.ViewportToWorldPoint (pos);

        movement.Set(h, 0, v);
        movement = movement.normalized * m_moveSpeed * Time.deltaTime;

        m_Rigidbody.MovePosition(transform.position + movement);


		//print ("Position in viewport: " + pos.x + ", " + pos.y);
    }
}
