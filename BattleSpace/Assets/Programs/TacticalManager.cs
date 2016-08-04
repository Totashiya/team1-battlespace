using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TacticalManager : MonoBehaviour {

	public Transform OriginalSpawn;
	public Transform PlayerTransform;
	public GameObject AdvancedEnemy;
	public GameObject ShieldEnemy;
	public GameObject BasicEnemy;
	public float FireRate;
	public int spawndebugger;

	private int enemiesdestroyed;
	public FlankerManager[] m_Flankers;
	public ShieldManager[] Shielders;
	public BasicManager[] Basics;
	private float targettime;
	// Use this for initialization
	void Start () {
		enemiesdestroyed = 0;
		for (int i = 0; i < m_Flankers.Length; i++) {
			m_Flankers [i].m_Instance = Instantiate (AdvancedEnemy, m_Flankers[i].m_SpawnPoint.position, m_Flankers[i].m_SpawnPoint.rotation) as GameObject;
			m_Flankers [i].m_FlankerNumber = i + 1;
			m_Flankers [i].m_TotalFlankers = spawndebugger;
		}
		targettime = Time.time + FireRate;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > targettime) {
			for (int i = 0; i < m_Flankers.Length; i++) {
				m_Flankers[i].m_FireSignal = true;
			}
			targettime = Time.time + FireRate;
		}
	}
	private void CreateShieldEnemy(){
		Vector3 CreatedEnemy = OriginalSpawn.position;
		GameObject ShielderEnemy = Instantiate(ShieldEnemy,CreatedEnemy, OriginalSpawn.rotation) as GameObject;
	}
}