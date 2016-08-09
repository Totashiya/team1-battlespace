using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

    public float fadeTime = 0.1f;

	public GameObject NewRecordText;

	public Text ScoreValue;
	public Text HighScoreValue;

	int m_HighScore;
	int m_Score;

	void Start() {
		m_HighScore = PlayerPrefs.GetInt ("HighestScore");
		m_Score = PlayerPrefs.GetInt ("FinalScore");
		SetUI ();
	}

	void SetUI() {
		if(m_Score > m_HighScore) {
			NewRecordText.SetActive (true);
			PlayerPrefs.SetInt ("HighestScore", m_Score);
		}
		ScoreValue.text = m_Score.ToString();
		HighScoreValue.text = "HIGH SCORE: " + m_HighScore.ToString();
	}

    public void sendMessage(string message) {
        switch (message) {
            case "retry":
                // switch scene to Main
                StartCoroutine(Retry());
                break;
            case "return":
                // switch scene to main menu
                StartCoroutine(Return());
                break;
            default:
                break;
        }
    }

    IEnumerator Retry() {
        gameObject.GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);

        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    IEnumerator Return() {
        gameObject.GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);

        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
