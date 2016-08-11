using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float m_rotateSpeed = 20f;

    public float m_defaultSpeed = 14f;
    public float m_slowSpeed = 10f;

	public float leftBorder = 0.03f;
	public float rightBorder = 0.97f;
	public float topBorder = 0.9f;
	public float botBorder = 0.1f;

    public bool isForward = false;
    public bool isReverse = false;

    float m_moveSpeed = 14f;

    Rigidbody m_Rigidbody;

    Vector3 movement;

	void Start () {
        m_Rigidbody = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
        m_Rigidbody.Sleep();

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if(Input.GetButton("slow")) {
            m_moveSpeed = m_slowSpeed;
        }
        else {
            m_moveSpeed = m_defaultSpeed;
        }
        Move(horizontal, vertical);
	}

    void Move(float h, float v) {
		Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
		pos.x = Mathf.Clamp (pos.x, leftBorder, rightBorder);
		pos.y = Mathf.Clamp (pos.y, botBorder, topBorder);
		transform.position = Camera.main.ViewportToWorldPoint (pos);

        movement.Set(h, 0, v);
        movement = movement.normalized * m_moveSpeed * Time.deltaTime;

        if (h == 1) {
            m_Rigidbody.rotation = Quaternion.Lerp(m_Rigidbody.rotation, Quaternion.Euler(-120, -90, 90), m_rotateSpeed * Time.deltaTime);
        }
        else if (h == -1) {
            m_Rigidbody.rotation = Quaternion.Lerp(m_Rigidbody.rotation, Quaternion.Euler(-60, -90, 90), m_rotateSpeed * Time.deltaTime);
        }
        else {
            m_Rigidbody.rotation = Quaternion.Lerp(m_Rigidbody.rotation, Quaternion.Euler(-90, 0, 0), m_rotateSpeed * Time.deltaTime);
        }

        m_Rigidbody.MovePosition(transform.position + movement);

        if(v == 0) {
            isForward = false;
        }

        else {
            isForward = true;
        }

        if(v == 1) {
            isReverse = true;
        }

        else {
            isReverse = false;
        }

		//print ("Position in viewport: " + pos.x + ", " + pos.y);
    }
}
