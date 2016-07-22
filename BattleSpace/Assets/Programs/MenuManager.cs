using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public void sendMessage(string message) {
        switch(message) {
            case "play":
                SceneManager.LoadScene("Main", LoadSceneMode.Single);
                break;
            case "about":
                break;
            case "credits":
                break;
            case "quit":
                Application.Quit();
                break;
        }
    }
}
