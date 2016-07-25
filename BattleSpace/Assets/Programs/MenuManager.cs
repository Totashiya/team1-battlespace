﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public GameObject aboutPanel;
    public GameObject creditsPanel;

    bool about_isEnabled = false;
    bool credits_isEnabled = false;

    public void sendMessage(string message) {
        switch(message) {
            case "play":

                SceneManager.LoadScene("Main", LoadSceneMode.Single);
                break;

            case "about":
                creditsPanel.SetActive(false);
                if (about_isEnabled) {
                    about_isEnabled = false;
                    aboutPanel.SetActive(false);
                }
                else {
                    about_isEnabled = true;
                    aboutPanel.SetActive(true);
                }

                aboutPanel.SetActive(about_isEnabled);

                break;

            case "credits":
                aboutPanel.SetActive(false);
                if (credits_isEnabled) {
                    credits_isEnabled = false;
                    creditsPanel.SetActive(false);
                }
                else {
                    credits_isEnabled = true;
                    creditsPanel.SetActive(true);
                }
                break;

            case "quit":
                Application.Quit();
                break;
        }
    }    
}
