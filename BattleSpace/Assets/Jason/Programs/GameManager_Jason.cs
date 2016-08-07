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
	public float EnemyCoeffiecient;
	public float MaximumEnemies;
	public int scale;
	public int starter;

	private float target;
	private float EnemyNumberDecimal;
	private int EnemyNumber;
	private int WaveNumber;
	private int prevEnemyNumber;
	// Use this for initialization
	void Start () {
        Physics.IgnoreLayerCollision(8, 9);
		GameObject m_Player = Instantiate (Player, PlayerSpawn.position, PlayerSpawn.rotation) as GameObject;

		//for (int i = 0; i < m_InitialSpawn; i++){
		//	CreateEnemy(i-m_InitialSpawn/2);
		//}
		target = Time.time + m_SpawnRate;
		WaveNumber = 1;
		CreateEnemy (Random.Range (-10f, 10f), 0f);
	}

	// Update is called once per frame
	void Update () {
		if (Time.time > target) {
			NextWave ();
			target = Time.time + m_SpawnRate;
		}
	}
	private void CreateEnemy(float x, float y){
		Vector3 Compensation = new Vector3 (x, 0f, y);
		Vector3 CreatedEnemy = OriginalSpawn.position + Compensation;
		GameObject CreatEnemy = Instantiate(Enemy,CreatedEnemy, OriginalSpawn.rotation) as GameObject;
	}
	private void NextWave(){
		EnemyNumberDecimal = -(EnemyCoeffiecient / WaveNumber) + MaximumEnemies;
		EnemyNumber = (int) Mathf.Round (EnemyNumberDecimal);
		if (EnemyNumber == prevEnemyNumber) {
			EnemyNumber -= 1;
		}
		float k = 40 / EnemyNumber;
		for (int i = 0; i < EnemyNumber; i++) {
			CreateEnemy ((i * k) - 17, EnemyNumber % 2);
		}
		WaveNumber++;
		prevEnemyNumber = EnemyNumber;
	}
}
