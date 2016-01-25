using UnityEngine;
using System.Collections;

public class Button_Pause : MonoBehaviour {

	public bool paused = false;

	void OnMouseDown() {
		if (paused) {
			Time.timeScale = 1;
			paused = false;
		} else {
			Time.timeScale = 0;
			paused = true;
		}
	}
}
