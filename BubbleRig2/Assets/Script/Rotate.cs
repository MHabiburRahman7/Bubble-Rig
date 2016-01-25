using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public bool clokWise;
	public float smoot = 0.1f, degree = 90f;
	public Vector3 nowV, nextV;
	public int stat;
	public GameObject pipeDest;
	public Transform shouldPlace;

	void Start () {
		nowV = nextV = new Vector3 (transform.rotation.x, transform.rotation.y, transform.rotation.z);
//		MoveAway (pipeDest);
		pipeDest = GameObject.Find ("DestroyerPipa");
		if (!pipeDest) {
			print("Ngga ada pipeDest");
		}
	}
	
	void OnMouseDown(){
		if (clokWise)
			nextV.z = nowV.z + 90.0f;
		else
			nextV.z = nowV.z - 90.0f;
		this.transform.rotation = Quaternion.Euler(nextV);
		nowV = nextV;
		nowV.z%=360f;
	}

	void Update () {
		if (nowV.z == 0f) {
			stat = 1;
			MoveAway(pipeDest);
		}
		else if (nowV.z == 90f || nowV.z == -90f) {
			stat = 2;
			MoveAway(pipeDest);
		} 
		else if (nowV.z == 180f || nowV.z == -180f) {
			stat = 3;
			MoveBack(pipeDest);
		} 
		else if (nowV.z == 270f || nowV.z == -270f) {
			stat = 4;
			MoveBack(pipeDest);
		}
	}

	void MoveAway(GameObject pipe){
		//float away = 14f;
		pipe.transform.position = new Vector3 (14f , 12f , 0f);
	}

	void MoveBack(GameObject pipe){
		pipe.transform.position = shouldPlace.transform.position;
	}
}