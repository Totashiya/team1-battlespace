using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class FlankerManager{

	public Transform m_Player;
	public Transform m_SpawnPoint;
	[HideInInspector] public int m_FlankerNumber;
	[HideInInspector] public int m_TotalFlankers;
	[HideInInspector] public bool m_FireSignal;
	[HideInInspector] public Rigidbody m_Self;
	[HideInInspector] public GameObject m_Instance;

	//private FlankerAI m_AI;
	// Use this for initialization
	void Start () {
		
		//m_AI = m_Instance.GetComponent<FlankerAI>();

	}
	
	// Update is called once per frame
	void Update () {
		if (m_FireSignal == true) {
			//m_AI.Fire();
			m_FireSignal = false;
		}

	}
	void FixedUpdate(){
		m_Self.transform.LookAt (m_Player);
	}

}
