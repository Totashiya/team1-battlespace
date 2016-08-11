using UnityEngine;
using System.Collections;

public class EarnedText : MonoBehaviour {

    public float lifeTime = 1f;

	void Start () {
        Destroy(gameObject, lifeTime);
	}
}
