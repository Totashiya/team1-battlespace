// Shop
// After certain waves, enemies will temporarily stop spawning.
// A "shop" (UI) will appear prompting the player to choose a certain permanent  upgrade.
// Upgrades include: Increased  
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    public float maxFireRate = 0.2f;
    public float maxSpeed = 20f;

    public Button upgrade1Button;
    public bool upgrade1Enabled = true;
    public Button upgrade2Button;
    public bool upgrade2Enabled = true;

    public void sendMessage(string message) {
        switch (message) {
            case "fire rate":
                print("Upgrade fire rate");
                GameObject.Find("PlayerCapsule(Clone)").GetComponent<Player_Firing>().fireRate -= (float)0.025;

                GameObject.Find("GameManager").GetComponent<GameManager_Jason>().stopSpawn = false;
                GameObject.Find("GameManager").GetComponent<GameManager_Jason>().scoreToStore += 1500;
                gameObject.SetActive(false);

                if (GameObject.Find("PlayerCapsule(Clone)").GetComponent<Player_Firing>().fireRate <= maxFireRate) {
                    upgrade1Button.interactable = false;
                    upgrade1Enabled = false;
                }

                break;

            case "movement speed":
                print("Upgrade movement speed");
                GameObject.Find("PlayerCapsule(Clone)").GetComponent<PlayerMovement>().m_defaultSpeed += 1;

                GameObject.Find("GameManager").GetComponent<GameManager_Jason>().stopSpawn = false;
                GameObject.Find("GameManager").GetComponent<GameManager_Jason>().scoreToStore += 1500;
                gameObject.SetActive(false);

                if (GameObject.Find("PlayerCapsule(Clone)").GetComponent<PlayerMovement>().m_defaultSpeed >= maxSpeed) {
                    upgrade2Button.interactable = false;
                    upgrade2Enabled = false;
                }

                break;
        }
    }
}