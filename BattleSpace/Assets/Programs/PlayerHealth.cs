using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

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

    float m_CurrentHealth;
    //bool isDead;

    void Start() {
        // When the player is enabled (change function name to onEnable), reset its health and its death status
        m_CurrentHealth = m_StartingHealth;
        //// isDead = false;

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
    }

    void SetText() {
        m_HealthValue.text = m_CurrentHealth + "<size=20>/200</size>";
        m_HealthValue.color = Color.Lerp(m_ZeroHealthTextColor, m_FullHealthTextColor, m_CurrentHealth / m_StartingHealth);

        // Update the text in the lives label
        m_LivesValue.text = "Lives: " + "<size=48>" + m_Lives + "</size>";
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Q)) {
            m_CurrentHealth -= 10;
            Debug.Log("Current health: " + m_CurrentHealth);
            SetHealthUI();
        }
        SetText();
    }

    /*
     * if(isDead) {
     *      lives--;
     * }
     *
     * if(lives == 0) GameOver();
     */
}
