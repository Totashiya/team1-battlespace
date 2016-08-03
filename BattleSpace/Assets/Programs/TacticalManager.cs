using UnityEngine;
using System.Collections;

public class TacticalManager : MonoBehaviour {

	public Transform OriginalSpawn;
	public Transform PlayerTransform;
	public Transform Transform1;
	public Transform Transform2;
	public Transform Transform3;
	public Transform Transform4;
	public Transform Transform5;
	public Transform Transform6;
	public Transform Transform7;
	public Transform Transform8;
	public GameObject AdvancedEnemy;
	public GameObject ShieldEnemy;
	public GameObject BasicEnemy;

	public int spawndebugger;

	private int enemiesdestroyed;
	public FlankerManager[] Flankers;
	public ShieldManager[] Shielders;
	public BasicManager[] Basics;
	// Use this for initialization
	void Start () {
		enemiesdestroyed = 0;
		for (int i = 0; i < spawndebugger; i++) {
			Flankers [i].m_Instance = Instantiate (AdvancedEnemy, OriginalSpawn.position, OriginalSpawn.rotation) as GameObject;
			Flankers [i].m_FlankerNumber = i + 1;
			Flankers [i].m_TotalFlankers = spawndebugger;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
	private void CreateShieldEnemy(){
		Vector3 CreatedEnemy = OriginalSpawn.position;
		GameObject ShielderEnemy = Instantiate(ShieldEnemy,CreatedEnemy, OriginalSpawn.rotation) as GameObject;
	}
}