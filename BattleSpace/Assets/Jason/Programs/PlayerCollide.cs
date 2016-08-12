using UnityEngine;
using System.Collections;

public class PlayerCollide : MonoBehaviour {

    public GameObject EnemyCollisionParticles;

    void OnCollisionEnter(Collision col) {
        PlayerHealth playerHealth = GameObject.Find("GameManager").GetComponent<PlayerHealth>();
        if (col.gameObject.tag == "Enemies") {
            Debug.Log("Player collided with enemy");
            playerHealth.takeDamage(20);
            GameObject CollisionExplosion = Instantiate(EnemyCollisionParticles, col.gameObject.transform.position, col.gameObject.transform.rotation) as GameObject;
            col.gameObject.GetComponent<AudioSource>().Play();
            col.gameObject.transform.position = new Vector3(1000, 0, 0);
            Destroy(col.gameObject, col.gameObject.GetComponent<AudioSource>().clip.length);
            Destroy(CollisionExplosion, EnemyCollisionParticles.GetComponent<ParticleSystem>().duration);
        }
    }
}
