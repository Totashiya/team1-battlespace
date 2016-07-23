using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int m_SpawnRate;
	public int m_InitialSpawn;
	public Transform OriginalSpawn;
	public Rigidbody Enemy;
	/*
	public Transform PlayerTransform;
	public int scale;
	public int starter;
	public GameObject EnemyZero;
	public GameObject EnemyOne;
	public GameObject EnemyTwo;
	public GameObject EnemyThree;

	private int en;
	private int eu;
	private int ed;
	private int et;
	private int points;
*/
	private float time;
	// Use this for initialization
	void Start () {
/*		en = 0;
		eu = 0;
		ed = 0;
		et = 0;
		points = 0;

*/
		for (int i = 0; i < m_InitialSpawn; i++){
			CreateEnemy(i-m_InitialSpawn/2);
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (time % m_SpawnRate == 0) {
			CreateEnemy ();
		}
		time += Time.deltaTime;
	}
	private void CreateEnemy(float horizontaloffset = 0f){
		Vector3 Compensation = new Vector3 (horizontaloffset*5, 0f, 0f);
		Vector3 CreatedEnemy = OriginalSpawn.position + Compensation;
		GameObject CreatEnemy = Instantiate(Enemy,CreatedEnemy, OriginalSpawn.rotation) as GameObject;
	}
}
