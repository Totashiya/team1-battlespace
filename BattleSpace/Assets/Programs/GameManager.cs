using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int m_SpawnRate;
	public int m_InitialSpawn;
	public Transform OriginalSpawn;
	public Rigidbody Enemy;
	public Transform TacticalReturn;

	public int scale;
	public int starter;

	private float target;

	// Use this for initialization
	void Start () {



		for (int i = 0; i < m_InitialSpawn; i++){
			CreateEnemy(i-m_InitialSpawn/2);
		}
		target = Time.time + m_SpawnRate;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > target) {
			CreateEnemy ();
			target = Time.time + m_SpawnRate;
		}
	}
	private void CreateEnemy(float horizontaloffset = 0f){
		Vector3 Compensation = new Vector3 (horizontaloffset*5, 0f, 0f);
		Vector3 CreatedEnemy = OriginalSpawn.position + Compensation;
		GameObject CreatEnemy = Instantiate(Enemy,CreatedEnemy, OriginalSpawn.rotation) as GameObject;
	}
}
