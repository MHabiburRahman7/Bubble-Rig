using UnityEngine;
using System.Collections;


public class TimeLimitScore : MonoBehaviour {

	public int scor, limNumb, waktu, limit, finalTime, timeStart, point = 0;
	public GameObject tank, spawner, Explode, mainBack, wining;
	public int fontSiz;
	public bool gameOver, win, once = false, bomb;
	private Vector2 mid, exploisonV;

	int lim(){
		limNumb = Random.Range (10, 20);
		return limNumb;
	}

	void Start(){
		Time.timeScale = 1;
		timeStart = (int)Time.time;
		gameOver = win = bomb = false;
		tank = GameObject.FindGameObjectWithTag ("tank");
		spawner = GameObject.FindGameObjectWithTag ("Respawn");
		fontSiz = tank.GetComponent<Tank> ().fontSize;;
		limit = lim ();
		mid = exploisonV = mainBack.transform.position;
	}

	void Update(){
		scor = tank.GetComponent<Tank> ().score;
		bomb = tank.GetComponent<Tank> ().lose;
		if (scor >= limit || bomb) {
			gameOver = true;
			point = 0;
			if(scor == limit){ win = true;
				if(waktu<=45) point = 5;
				else if(waktu>45 && waktu<=60) point = 3;
				else point=1;
			}
		}
		else waktu = (int)Time.time-timeStart;

		if (gameOver) {
			if(!once){
				finalTime = waktu;
				if(win) Instantiate(wining, mid, Quaternion.identity);
				else {
					for(int i=0;i<3;i++) Invoke("exploded", 0.5f);
				}
				once = true;
			}
		}
	}

	void exploded(){
		exploisonV.y = Random.Range (mid.y - 7.2f, mid.y + 7.2f);
		exploisonV.x = Random.Range (mid.x - 3f, mid.x + 3f);
		Instantiate (Explode, exploisonV, Quaternion.identity);
		Invoke("explodeExit", 0.6f);
	}

	void explodeExit(){
		Destroy (Explode);
	}

	void OnGUI(){
		GUI.skin.label.fontSize = fontSiz;
		if (gameOver || win) {
			GUI.Label (new Rect (Screen.width * 50 / 100, Screen.height * 70 / 100, 100, 90), "Your time is :" + finalTime);
			GUI.Label (new Rect(Screen.width *50/100, Screen.height *80/100, 120,60), "Your point is :" +point);
		}else 
		{
			GUI.Label (new Rect (Screen.width *16/100, Screen.height *16/100, 100, 50), " " + limit);
			GUI.Label (new Rect (Screen.width *70/100, Screen.height *75/100, 100, 50), "Time :" + waktu);
		}

	}
}