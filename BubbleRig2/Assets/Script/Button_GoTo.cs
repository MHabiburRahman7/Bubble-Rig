using UnityEngine;
using System.Collections;

public class Button_GoTo : MonoBehaviour {

	public string LevelName;
	void OnMouseDown(){
		Application.LoadLevel (LevelName);
	}
}
