using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerBullet : MonoBehaviour {

	// The player will earn more points the closer the enemy is to the bottom of the screen.
	// This will discourage spamming down a lane while rewarding difficult kills
	public int minEarned = 50;
	public int maxEarned = 1000;

    bool isColliding = false; // boolean to prevent multiple simultaneous collisions

    int earned;

    public Font earnedTextFont;

    GameObject HUD;
    GameObject EarnedTextObject;

    public GameObject EarnedTextPrefab;

    public GameObject EnemyExplosion;
    public GameObject MissileExplosion;

    PlayerScore playerScore;

    void Start () {
        HUD = GameObject.Find("HUD");
        playerScore = GameObject.Find("GameManager").GetComponent<PlayerScore>();
        gameObject.GetComponent<AudioSource>().Play();
    }

	void Update () {
        isColliding = false;	
	}

	void OnTriggerEnter(Collider other) {

        if (isColliding) return;
        else if (other.CompareTag("Enemies")) {
            isColliding = true;
            //Debug.Log("Hit an enemy");

			float enemyVPosition = other.transform.position.z;
			// print ("Enemy killed at position(Z) " + enemyVPosition.ToString ());

			float t = map (enemyVPosition, -14, 12, 0, 1);
			// print ("PlayerBullet: Ratio is " + t.ToString());

			earned = (int) Mathf.Lerp (minEarned, maxEarned, t);
			// print ("Player earns " + earned.ToString());

            playerScore.AddScore(earned);
            ShowEarned(earned, other.gameObject);

            Instantiate(EnemyExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);

            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().Sleep();

            Destroy(gameObject, GetComponent<AudioSource>().clip.length);
        }

        else if(other.gameObject.name == "HomingMissle(Clone)") {
            other.GetComponent<AudioSource>().Play();
            playerScore.AddScore(300);
            ShowEarned(300, other.gameObject);

            GameObject m_MissleExplosion = Instantiate(MissileExplosion, other.transform.position, other.transform.rotation) as GameObject;

            Destroy(other.gameObject);

            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().Sleep();

            Destroy(gameObject, other.GetComponent<AudioSource>().clip.length);
            Destroy(m_MissleExplosion, m_MissleExplosion.GetComponent<ParticleSystem>().duration);
        }
	}

    void ShowEarned(int earned, GameObject worldObject) {
        EarnedTextObject = Instantiate(EarnedTextPrefab);
        EarnedTextObject.transform.SetParent(HUD.transform);

        Text earnedText = EarnedTextObject.GetComponent<Text>();
        earnedText.text = "+" + earned.ToString();

        RectTransform CanvasRect = HUD.GetComponent<RectTransform>();

        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(worldObject.transform.position);
        Vector2 WorldObject_ScreenPosition = new Vector2(
            ((ViewportPosition.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f)),
            ((ViewportPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f)));

        EarnedTextObject.GetComponent<RectTransform>().anchoredPosition = WorldObject_ScreenPosition;
    }

	float map(float value, float low1, float high1, float low2, float high2) {
		return (low2 + (value - low1) * (high2 - low2) / (high1 - low1));
	}
}
