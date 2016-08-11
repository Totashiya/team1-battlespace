using UnityEngine;
using System.Collections;

public class EnemyExplosion : MonoBehaviour {

	void Start () {
        GetComponent<AudioSource>().Play();
        Destroy(gameObject, GetComponent<AudioSource>().clip.length);
	}
}
