/* This script gives bullets a limited lifetime after colliding with something. */

using UnityEngine;

public class BulletLife : MonoBehaviour {

    public float lifeTime = 3.0f; // set amount of time for the countdown

    bool timer = false; // when set to true, a countdown timer will start.

    void Update() {
        if(timer) {
            lifeTime -= Time.deltaTime;
            if(lifeTime <= 0.0f) {
                SelfDestruct();
                timer = false;
            }
        }
    }

    void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag == "Enemies") {
            SelfDestruct();
        }
        else {
            timer = true;
        }
    }

    void SelfDestruct() {
        Destroy(this.gameObject);
    }
}
