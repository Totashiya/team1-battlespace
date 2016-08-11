using UnityEngine;
using System.Collections;

public class GameManager_Jason : MonoBehaviour {

    // public GameObject m_Player;

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
	public int StartingWave;

	private float target;
	private float EnemyNumberDecimal;
	private int EnemyNumber;
	private int WaveNumber;
	private int prevEnemyNumber;

	void Start () {
        Physics.IgnoreLayerCollision(8, 9); // ignore collisions between enemies and enemy bullets
        Physics.IgnoreLayerCollision(9, 10); // ignore collisions between player and enemy bullets
        Instantiate(Player, PlayerSpawn.position, PlayerSpawn.rotation);

		//for (int i = 0; i < m_InitialSpawn; i++){
		//	CreateEnemy(i-m_InitialSpawn/2);
		//}
		target = m_SpawnRate;
		WaveNumber = StartingWave;
        NextWave();
	}

	void Update () {
		//print (Time.time);
		if (Time.time > target) {
			NextWave ();
			target = Time.time + m_SpawnRate;
		}
	}

	private void CreateEnemy(float x, float y){
		Vector3 Compensation = new Vector3 (x, 0f, y);
		Vector3 CreatedEnemy = OriginalSpawn.position + Compensation;
		Instantiate(Enemy,CreatedEnemy, OriginalSpawn.rotation);
	}

    private void NextWave() {
        EnemyNumberDecimal = -(EnemyCoeffiecient / WaveNumber) + MaximumEnemies;
        EnemyNumber = (int)Mathf.Round(EnemyNumberDecimal);
        if (EnemyNumber == prevEnemyNumber) {
            EnemyNumber -= 1;
        }
        float k = 0;
        if (EnemyNumber <= 1) {
			CreateEnemy (0f, 0f);
        }
        else {
            k = 36 / EnemyNumber;
			for (int i = 0; i < EnemyNumber; i++) {
				CreateEnemy((i * k) - 13, EnemyNumber % 2);
			}
        }
        
        WaveNumber++;
        prevEnemyNumber = EnemyNumber;
    }

    public IEnumerator Respawn() {
        PlayerHealth playerHealth = GameObject.Find("GameManager").GetComponent<PlayerHealth>();

        //Debug.Log("Respawning");
        Destroy(GameObject.Find("PlayerCapsule(Clone)"));

        Time.timeScale = 0.75f; // make everything slow before respawning

        yield return new WaitForSeconds(3f); // wait 3 seconds before respawning

        Time.timeScale = 1f;
        Instantiate(Player, PlayerSpawn.position, PlayerSpawn.rotation);
        playerHealth.m_CurrentHealth = 200f;
    }

}
