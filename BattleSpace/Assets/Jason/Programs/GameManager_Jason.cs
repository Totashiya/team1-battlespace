using UnityEngine;
using System.Collections;

public class GameManager_Jason : MonoBehaviour {

    // public GameObject m_Player;

    public float m_SpawnRate;
	public int m_InitialSpawn;
	public Transform OriginalSpawn;
	public Rigidbody BasicEnemy;
	public Rigidbody MissileEnemy;
	public Rigidbody FlankerEnemy;
	public Rigidbody Player;
	public Transform TacticalReturn;
	public Transform PlayerSpawn;
	public float EnemyCoeffiecient;
	public float MaximumEnemies;
	public int scale;
	public int starter;
	public int StartingWave;
    public int WaveNumber;

    public GameObject Shop;
    public int scoreToStore = 5000;
    public bool stopSpawn = false;

    private float target;
	private float EnemyNumberDecimal;
	private int EnemyNumber;
	private int prevEnemyNumber;

	void Start () {
        Time.timeScale = 1.0f;
        Physics.IgnoreLayerCollision(8, 9); // ignore collisions between basic enemies and enemy lasers
        Physics.IgnoreLayerCollision(9, 11); // ignore collisions between enemy lasers and enemy missles
        Physics.IgnoreLayerCollision(9, 10); // ignore collisions between player and basic enemy lasers (NOT ENEMY MISSLES)
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
		if (Time.time > target && !stopSpawn) {
			NextWave ();
			target = Time.time + m_SpawnRate;
		}

        if(GetComponent<PlayerScore>().m_Score >= 5000) {
            stopSpawn = true;
        }

        if(stopSpawn) {
            Shop.SetActive(true);
        }
	}

	private void CreateEnemy(float x, float y, int EnemyNumber){
        //print("CreateEnemy()");
		Vector3 Compensation = new Vector3 (x, 0f, y);
		Vector3 CreatedEnemy = OriginalSpawn.position + Compensation;
		if (EnemyNumber > 5) {
			if (Mathf.Abs (x) > 8 && Mathf.Abs (x) < 13) {
                //print("Spawned FlankerEnemy");
                Instantiate(FlankerEnemy, CreatedEnemy, OriginalSpawn.rotation);
			}
			else if (Mathf.Abs (x) >= 12) {
                //print("Spawned MissileEnemy");
                Instantiate(MissileEnemy, CreatedEnemy, OriginalSpawn.rotation);
			}
			else {
				//print("Spawned BasicEnemy");
				Instantiate(BasicEnemy, CreatedEnemy, OriginalSpawn.rotation);
			}
		}  else {
			//print("Spawned BasicEnemy");
			Instantiate(BasicEnemy, CreatedEnemy, OriginalSpawn.rotation);
		}
	}

    private void NextWave() {
        print("NextWave()");
        //print("Wave number: " + (WaveNumber - StartingWave + 1).ToString());
        EnemyNumberDecimal = -(EnemyCoeffiecient / WaveNumber) + MaximumEnemies;
        EnemyNumber = (int)Mathf.Round(EnemyNumberDecimal);
        //print("Number of enemies: " + EnemyNumber);
        if (EnemyNumber == prevEnemyNumber) {
            EnemyNumber -= 1;
        }
        float k = 0;
        if (EnemyNumber <= 1) {
			CreateEnemy (0f, 0f,EnemyNumber);
        }
        else {
			k = 28 / (EnemyNumber-1);
			for (int i = 0; i < EnemyNumber; i++) {
				CreateEnemy((i * k) - 14, EnemyNumber % 2,EnemyNumber);
			}
        }
        print("Completed spawning wave " + WaveNumber.ToString());
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

        StartCoroutine(Invincible(GameObject.Find("PlayerCapsule(Clone)"), 2));
    }

    public GameObject m_InvincibleParticles;
    public GameObject m_InvincibleText;

    IEnumerator Invincible(GameObject inv, float time) {
        print("Player is invincible!");

        Vector3 pos = inv.transform.position;
        Quaternion rot = inv.transform.rotation;

        // Show particles indicating invincibility 
        Instantiate(m_InvincibleParticles, pos, rot, inv.transform);

        // Show text informing the player that they're invincible
        m_InvincibleText.SetActive(true);

        foreach(Collider c in inv.GetComponents<BoxCollider>()) {
            c.enabled = false;
        }

        yield return new WaitForSeconds(time);

        foreach (Collider c in inv.GetComponents<BoxCollider>()) {
            c.enabled = true;
        }

        Destroy(GameObject.Find("InvincibleParticles(Clone)"));
        m_InvincibleText.SetActive(false);

        print("Player is no longer invincible");
    }
    
}
