using System;
using UnityEngine;
using System.Collections;
[Serializable]
public class ShieldManager : MonoBehaviour {
	public Rigidbody m_Player;
	public float scalefactor;
	[HideInInspector] public int m_ShieldNumber;
	[HideInInspector] public int m_TotalShielders;
	[HideInInspector] public bool m_FireSignal;
	public Rigidbody m_Self;
	[HideInInspector] public GameObject m_Instance;

	// private float m_targetfiretime;	// commented out to remove warning
	// private int m_position;			// commented out to remove warning
	// private float m_degrees;			// commented out to remove warning
	private Vector3 m_relativelocation;
	private float m_xlocation;
	private float m_ylocation;
	private int m_prevShieldNumber;
	// Use this for initialization
	void Start () {
		// m_targetfiretime = 0f;
		// m_degrees = 0f;
		// m_position = 0;
		switch (m_TotalShielders) {
		case 1:
			m_xlocation = 0.5f;
			m_ylocation = 0.5f;
			break;
		case 2:
			if (m_ShieldNumber == 1) {
				m_xlocation = 0.5f;
				m_ylocation = 0.5f;
			} else {
				m_xlocation = 0.6f;
				m_ylocation = 0.6f;
			}
			break;
		case 3:
			switch (m_ShieldNumber) {
			case 1:
				m_xlocation = 0.4f;
				m_ylocation = 0.6f;
				break;
			case 2:
				m_xlocation = 0.5f;
				m_ylocation = 0.5f;
				break;
			case 3:
				m_xlocation = 0.6f;
				m_ylocation = 0.6f;
				break;
			}
			break;
		case 4:
			switch (m_ShieldNumber) {
			case 1:
				m_xlocation = 0.25f;
				m_ylocation = 0.4f;
				break;
			case 2:
				m_xlocation = 0.4f;
				m_ylocation = 0.6f;
				break;
			case 3:
				m_xlocation = 0.6f;
				m_ylocation = 0.6f;
				break;
			case 4:
				m_xlocation = 0.75f;
				m_ylocation = 0.4f;
				break;
			}
			break;
		case 5:
			switch (m_ShieldNumber) {
			case 1:
				m_xlocation = 0.3f;
				m_ylocation = 0.3f;
				break;
			case 2:
				m_xlocation = 0.4f;
				m_ylocation = 0.5f;
				break;
			case 3:
				m_xlocation = 0.5f;
				m_ylocation = 0.6f;
				break;
			case 4:
				m_xlocation = 0.6f;
				m_ylocation = 0.5f;
				break;
			case 5:
				m_xlocation = 0.7f;
				m_ylocation = 0.3f;
				break;
			}
			break;
		case 6:
			switch (m_ShieldNumber) {
			case 1:
				m_xlocation = 0.3f;
				m_ylocation = 0.45f;
				break;
			case 2:
				m_xlocation = 0.4f;
				m_ylocation = 0.6f;
				break;
			case 3:
				m_xlocation = 0.4f;
				m_ylocation = 0.3f;
				break;
			case 4:
				m_xlocation = 0.6f;
				m_ylocation = 0.3f;
				break;
			case 5:
				m_xlocation = 0.6f;
				m_ylocation = 0.6f;
				break;
			case 6:
				m_xlocation = 0.7f;
				m_ylocation = 0.45f;
				break;
			}
			break;
		}
		m_prevShieldNumber = m_TotalShielders;
		m_relativelocation = new Vector3 (m_Player.position.x + m_ylocation*scalefactor,0f,m_Player.position.z + m_xlocation*scalefactor);
	}

	// Update is called once per frame
	void Update () {
		if (m_prevShieldNumber != m_ShieldNumber) {
			switch (m_TotalShielders) {
			case 1:
				m_xlocation = 0.5f;
				m_ylocation = 0.5f;
				break;
			case 2:
				if (m_ShieldNumber == 1) {
					m_xlocation = 0.5f;
					m_ylocation = 0.5f;
					break;
				} else {
					m_xlocation = 0.6f;
					m_ylocation = 0.6f;
					break;
				}
			case 3:
				switch (m_ShieldNumber) {
				case 1:
					m_xlocation = 0.4f;
					m_ylocation = 0.6f;
					break;
				case 2:
					m_xlocation = 0.5f;
					m_ylocation = 0.5f;
					break;
				case 3:
					m_xlocation = 0.6f;
					m_ylocation = 0.6f;
					break;
				}
				break;
			case 4:
				switch (m_ShieldNumber) {
				case 1:
					m_xlocation = 0.25f;
					m_ylocation = 0.4f;
					break;
				case 2:
					m_xlocation = 0.4f;
					m_ylocation = 0.6f;
					break;
				case 3:
					m_xlocation = 0.6f;
					m_ylocation = 0.6f;
					break;
				case 4:
					m_xlocation = 0.75f;
					m_ylocation = 0.4f;
					break;
				}
				break;
			case 5:
				switch (m_ShieldNumber) {
				case 1:
					m_xlocation = 0.3f;
					m_ylocation = 0.3f;
					break;
				case 2:
					m_xlocation = 0.4f;
					m_ylocation = 0.5f;
					break;
				case 3:
					m_xlocation = 0.5f;
					m_ylocation = 0.6f;
					break;
				case 4:
					m_xlocation = 0.6f;
					m_ylocation = 0.5f;
					break;
				case 5:
					m_xlocation = 0.7f;
					m_ylocation = 0.3f;
					break;
				}
				break;
			case 6:
				switch (m_ShieldNumber) {
				case 1:
					m_xlocation = 0.3f;
					m_ylocation = 0.45f;
					break;
				case 2:
					m_xlocation = 0.4f;
					m_ylocation = 0.6f;
					break;
				case 3:
					m_xlocation = 0.4f;
					m_ylocation = 0.3f;
					break;
				case 4:
					m_xlocation = 0.6f;
					m_ylocation = 0.3f;
					break;
				case 5:
					m_xlocation = 0.6f;
					m_ylocation = 0.6f;
					break;
				case 6:
					m_xlocation = 0.7f;
					m_ylocation = 0.45f;
					break;
				}
				break;
			}
		}
		m_prevShieldNumber = m_TotalShielders;
		m_relativelocation = new Vector3 (m_Player.position.x + m_ylocation*scalefactor,0f,m_Player.position.z + m_xlocation*scalefactor);
		m_Self.MovePosition (m_relativelocation);
		m_Self.Sleep ();

	}
}
