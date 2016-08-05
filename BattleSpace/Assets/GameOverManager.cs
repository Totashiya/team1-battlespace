using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

    public float fadeTime = 0.1f;

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
