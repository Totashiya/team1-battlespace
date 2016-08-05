using UnityEngine;
using System.Collections;

public class GameManager_Jason : MonoBehaviour {

	public float m_SpawnRate;
	public int m_InitialSpawn;
	public Transform OriginalSpawn;
	public Rigidbody Enemy;
	public Rigidbody Player;
	public Transform TacticalReturn;
	public Transform PlayerSpawn;

	public int scale;
	public int starter;

	private float target;

	// Use this for initialization
	void Start () {

		GameObject m_Player = Instantiate (Player, PlayerSpawn.position, PlayerSpawn.rotation) as GameObject;

		//for (int i = 0; i < m_InitialSpawn; i++){
		//	CreateEnemy(i-m_InitialSpawn/2);
		//}
		target = Time.time + m_SpawnRate;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > target) {
			CreateEnemy ();
			target = Time.time + m_SpawnRate;
		}
	}
	private void CreateEnemy(){
		Vector3 Compensation = new Vector3 (Random.Range(-20f,20f),0f,0f);
		Vector3 CreatedEnemy = OriginalSpawn.position + Compensation;
		GameObject CreatEnemy = Instantiate(Enemy,CreatedEnemy, OriginalSpawn.rotation) as GameObject;
	}
}
