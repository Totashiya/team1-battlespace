/* Here we manage the score of the player currently playing, and show the
 * highest score (if it exists that is, if not show "New record!") ever achieved
 * To save values between game sessions, use PlayerPrefs.SetInt() and GetInt()
 * If the current score is EVER greater than the highest score, display "New Record! instead of the highest score
 */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScore : MonoBehaviour {

    public GameObject m_ScoreText;  // The gameobject that contains the text displaying the score.
    public GameObject m_HighestScoreText;   // The gameobject that contains the text displaying the highest score

    public int m_Score = 0;

    Text m_ScoreValue;              // Contains the text of the score.
    Text m_HighestScoreValue;

    public Color m_NewRecordColor;
    public Color m_NewRecordScoreColor;

    int m_HighestScore;

	void Start () {
        // Try to get the highest score to display.
        // If GetInt() returns 0, display the text "New Record!"
        m_HighestScore = PlayerPrefs.GetInt("HighestScore");

        m_ScoreValue = m_ScoreText.GetComponent<Text>();
        m_HighestScoreValue = m_HighestScoreText.GetComponent<Text>();
	
	}
	
	void Update () {
        SetScoreText();	
	}


    void SetScoreText() {
        // Set the text of the score and the highest score.
        // If the current score is EVER greater than the highest score, display "New Record! instead of the highest score
        // and set the highest score to the current score. Might need a reference to PlayerHeath to set the highscore upon game over.

        if(m_Score > m_HighestScore) {
            m_HighestScoreValue.color = m_NewRecordColor;
            m_HighestScoreValue.text = "New Record!";

            // also change the color of the current score (maybe)
            m_ScoreValue.color = m_NewRecordScoreColor;
        }

        else {
            m_HighestScoreValue.text = m_HighestScore.ToString();
        }

        m_ScoreValue.text = m_Score.ToString();
        
    }
}
