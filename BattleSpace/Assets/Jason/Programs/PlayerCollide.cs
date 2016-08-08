using UnityEngine;
using System.Collections;

public class PlayerCollide : MonoBehaviour {

    void OnCollisionEnter(Collision col) {
        PlayerHealth playerHealth = GameObject.Find("GameManager").GetComponent<PlayerHealth>();
        if (col.gameObject.tag == "Enemies") {
            Debug.Log("Player collided with enemy");
            playerHealth.takeDamage(20);
            Destroy(col.gameObject);
        }
    }
}
