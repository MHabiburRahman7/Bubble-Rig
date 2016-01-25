using UnityEngine;
using System.Collections;

public class Button_Mute : MonoBehaviour {

	public GameObject mainCam;
	public bool mute = false;
	void OnMouseDown(){
		if (!mute) {
			AudioListener.pause = true;
//			AudioListener.volume = 0;
			mute = true;
		} else {
			AudioListener.pause = false;
//			AudioListener.volume = 128;
			mute = false;
		}
	}
}
