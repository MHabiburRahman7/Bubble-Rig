using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour {

	public int score;
	public GameObject spawner, winLose;
	public string[] DefBallName = new string[10];
	public string[] numb;
	public int max, fontSize = 22;
	public bool lose, over;
	// Use this for initialization
	void Start () {
		max = spawner.GetComponent<Spawn> ().max;
		for (int i=0; i<max; i++) {
			DefBallName[i] = spawner.GetComponent<Spawn> ().DefBallName + i;
		}
		score = 0;
		lose = false;
	}

	void Update(){
		over = winLose.GetComponent<TimeLimitScore> ().gameOver;
	}

	void OnTriggerEnter2D(Collider2D col){ 
		if (col.gameObject.tag == "Ball") {
			numb = col.name.Split('_');
			int j = System.Convert.ToInt32(numb[1]);
			if(j==0) lose = true;
			if(!over)	score+=j;
			Destroy(col.gameObject);
		}
	}
	void OnGUI(){
			GUI.skin.box.fontSize = fontSize;
			GUI.Box (new Rect (Screen.width * 36 / 100, Screen.height * 18 / 100, 120, 50), "Score : " + score);
		}
}
