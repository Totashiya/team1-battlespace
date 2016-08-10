using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public GameManager gameManager;

    public float m_StartingHealth = 200f;
    public int m_Lives = 3;

    public Slider m_Slider;

    public Image m_FillImage;

    public Color m_FullHealthColor = new Color(255f, 255f, 255f, 90f); // Green color at full health
    public Color m_ZeroHealthColor = new Color (255f, 48f, 0f, 90f); // Red color at zero health
    public Color m_FullHealthTextColor = Color.green;
    public Color m_ZeroHealthTextColor = Color.red;

    public GameObject m_HealthText;
    Text m_HealthValue;

    public GameObject m_LivesText;
    Text m_LivesValue;

    public GameObject m_RespawnText;

	public float m_CurrentHealth;

    void Start() {
        // When the player is enabled (change function name to onEnable), reset its health and its death status
        m_CurrentHealth = m_StartingHealth;

        m_HealthValue = m_HealthText.GetComponent<Text>();
        m_LivesValue = m_LivesText.GetComponent<Text>();

        // Update the health slider's value and color
        SetHealthUI();

        // Update the health label text
        SetText();
    }

    void SetHealthUI() {
        // set the slider's value appropriately
        m_Slider.value = m_CurrentHealth;

        // interpolate the color of the slider between m_FullHealthColor and m_ZeroHealthColor based on current percentage of the starting health
        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, m_CurrentHealth / m_StartingHealth);

		SetText ();
    }

    void SetText() {
        m_HealthValue.text = m_CurrentHealth + "<size=20>/200</size>";
        m_HealthValue.color = Color.Lerp(m_ZeroHealthTextColor, m_FullHealthTextColor, m_CurrentHealth / m_StartingHealth);

        // Update the text in the lives label
        m_LivesValue.text = "Lives: " + "<size=48>" + m_Lives + "</size>";
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Q)) {
            Dead();
        }
        SetHealthUI();
    }

    void Dead() {
        if(m_Lives < 1) {
            StartCoroutine(gameManager.GameOver());
        }
        else {
            m_Lives--;
            
            StartCoroutine(gameObject.GetComponent<GameManager_Jason>().Respawn());
            StartCoroutine(RespawnTimer());
        }
    }

	public void takeDamage(int damage) {
		//Debug.Log ("PlayerHealth: Decreased health by 10");
        m_CurrentHealth -= damage;
		SetHealthUI ();

        if(m_CurrentHealth <= 0) {
            Dead();
        }
	}

    IEnumerator RespawnTimer() {
        m_RespawnText.SetActive(true);
        yield return new WaitForSeconds(3f);
        m_RespawnText.SetActive(false);
    }
}
