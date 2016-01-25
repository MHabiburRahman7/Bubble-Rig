using UnityEngine;
using System.Collections;

public class Exploison : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		Destroy (gameObject, 0.65f);
	}
}
