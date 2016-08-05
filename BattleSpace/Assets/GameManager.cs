using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

	public float fadeTime = 1f;

	// Use this for initialization
	void Start () { 
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator GameOver() {
		// do shit
		gameObject.GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);

		SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
	}
}