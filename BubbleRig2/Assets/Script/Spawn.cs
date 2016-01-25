using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public int max;
	public Transform[] pos;
	public GameObject[] balls;
	public GameObject control;
	public string DefPosName, DefBallName;
	public int timeGap;
	string[] posName = new string[10];
	string[] ballName = new string[10];
	public int spawnLoc, BallNumb;
	public bool over;

	private Vector2 spawnFix;
	
	void Start () {
		if (balls.Length <= pos.Length)
			max = pos.Length;
		else
			max = balls.Length;

		for (int i=0; i<max; i++) {
			posName[i] = DefPosName+i;
			ballName[i] = DefBallName+i;
		}
		over = false;
		control = GameObject.FindGameObjectWithTag ("MainControl");
		StartCoroutine (spawn ());
	}
	

	void Update(){
		over = control.GetComponent<TimeLimitScore> ().gameOver;

	}

	GameObject spawnPos(){
		spawnLoc = Random.Range (0, pos.Length);
		return GameObject.Find (posName [spawnLoc]);
	}
	GameObject spawnBal(){
		BallNumb = Random.Range (0, balls.Length);
		return Resources.Load(ballName [BallNumb]) as GameObject;
		//return GameObject.Find (ballName [BallNumb]);
	}
	public IEnumerator spawn(){
		while (!over) {
			spawnFix = spawnPos().transform.position;
			GameObject newBall = (GameObject)Instantiate(spawnBal(), spawnFix, Quaternion.identity);
			newBall.name = ballName[BallNumb];
			yield return new WaitForSeconds(timeGap);
		}
	}
}
