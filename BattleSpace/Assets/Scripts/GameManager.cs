using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

    //public PlayerScore scoreManager;

	public float fadeTime = 1f;

    int finalScore;

	public IEnumerator GameOver() {
        // Store the final score and then fade into the game over screen
        //finalScore = scoreManager.m_Score;
        //PlayerPrefs.SetInt("Final Score", finalScore);

        Time.timeScale = 0.5f; // slow down time as the screen dramatically fades to black

		gameObject.GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);

		SceneManager.LoadScene(2, LoadSceneMode.Single);
	}
}