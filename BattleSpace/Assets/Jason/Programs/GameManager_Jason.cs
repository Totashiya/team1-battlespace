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

	private float target;
	private float EnemyNumberDecimal;
	private int EnemyNumber;
	private int WaveNumber;
	private int prevEnemyNumber;
	// Use this for initialization
	void Start () {
        Physics.IgnoreLayerCollision(8, 9);
        Instantiate(Player, PlayerSpawn.position, PlayerSpawn.rotation);

		//for (int i = 0; i < m_InitialSpawn; i++){
		//	CreateEnemy(i-m_InitialSpawn/2);
		//}
		target = m_SpawnRate;
		WaveNumber = 70;
        NextWave();
	}

	// Update is called once per frame
	void Update () {
		print (Time.time);
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
        if (EnemyNumber == 0) {
            k = 17;
        }
        else {
            k = 40 / EnemyNumber;
        }
        for (int i = 0; i < EnemyNumber; i++) {
            CreateEnemy((i * k) - 17, EnemyNumber % 2);
        }
        WaveNumber++;
        prevEnemyNumber = EnemyNumber;
    }

    public IEnumerator Respawn() {
        PlayerHealth playerHealth = GameObject.Find("GameManager").GetComponent<PlayerHealth>();

        Debug.Log("Respawning");
        Destroy(GameObject.Find("PlayerCapsule(Clone)"));

        Time.timeScale = 0.75f; // make everything slow before respawning

        yield return new WaitForSeconds(3f); // wait 3 seconds before respawning

        Time.timeScale = 1f;
        Instantiate(Player, PlayerSpawn.position, PlayerSpawn.rotation);
        playerHealth.m_CurrentHealth = 200f;
    }

}
