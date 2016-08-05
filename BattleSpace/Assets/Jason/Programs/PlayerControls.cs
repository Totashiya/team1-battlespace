using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
	public int m_PlayerNumber = 1;         
	public float m_Speed = 12f;            
	public float m_TurnSpeed = 180f;       


	private string m_MovementAxisName;     
	private string m_YawAxisName;
/*	private string m_PitchAxisName;
	private string m_RollAxisName;
*/	private Rigidbody m_Rigidbody;         
	private float m_MovementInputValue;    
	private float m_YawInputValue;
/*	private float m_RollInputValue;
	private float m_PitchInputValue;
*/

	private void Awake()
	{
		m_Rigidbody = GetComponent<Rigidbody>();
	}


	private void OnEnable ()
	{
		m_Rigidbody.isKinematic = false;
		m_MovementInputValue = 0f;
		m_YawInputValue = 0f;
/*		m_RollInputValue = 0f;
		m_PitchInputValue = 0f;
*/		
	}


	private void OnDisable ()
	{
		m_Rigidbody.isKinematic = true;
	}


	private void Start()
	{
		m_MovementAxisName = "Thrust";
		m_YawAxisName = "Yaw";
/*		m_PitchAxisName = "Pitch";
		m_RollAxisName = "Roll";
*/	}

	private void Update()
	{
		// Store the player's input and make sure the audio for the engine is playing.
		m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
		m_YawInputValue = Input.GetAxis (m_YawAxisName);
/*		m_RollInputValue = Input.GetAxis (m_RollAxisName);
		m_PitchInputValue = Input.GetAxis (m_PitchAxisName);
*/
	}




	private void FixedUpdate()
	{
		// Move and turn the tank.
		Move();
		//Turn ();
		if (m_MovementInputValue + m_YawInputValue == 0){
			m_Rigidbody.Sleep ();
		}
	}


	private void Move()
	{
		// Adjust the position of the tank based on the player's input.
		Vector3 vmovement = transform.up *m_MovementInputValue *m_Speed *Time.deltaTime;

		// Adjust the position of the tank based on the player's input.
		Vector3 hmovement = transform.right * -m_YawInputValue *m_Speed *Time.deltaTime;


		// Apply this movement to the rigidbody's position
		m_Rigidbody.MovePosition (m_Rigidbody.position + vmovement+ hmovement);
	}


	/*private void Turn()
	{
		// Adjust the rotation of the tank based on the player's input.
		float yaw = m_YawInputValue *m_TurnSpeed * Time.deltaTime;
		float roll = m_RollInputValue * m_TurnSpeed * Time.deltaTime;
		float pitch = m_PitchInputValue * m_TurnSpeed * Time.deltaTime;

		Vector3 turnRotation = new Vector3 (pitch, roll, yaw);

		m_Rigidbody.AddTorque (m_Rigidbody.rotation * turnRotation);
	}*/
}
