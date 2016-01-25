using UnityEngine;
using System.Collections;

public class Button_Restart : MonoBehaviour {

	void OnMouseDown(){
		Application.LoadLevel (Application.loadedLevel);
	}
}
