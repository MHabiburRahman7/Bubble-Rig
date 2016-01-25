using UnityEngine;
using System.Collections;

public class CurvePipe : MonoBehaviour {

	public int count = 0;
	public bool right = false;
	public GameObject[] turns;
	public Transform[] belok;

	void Start(){
	}

	void Update(){
		if (count%2==0) {
			turns[0].transform.position = belok[0].transform.position;
			turns[1].transform.position = belok[1].transform.position;
			if(turns[0].transform.position == belok[0].position){
				print("InPosition turns 0");
			}
		} 
		else {
			turns[1].transform.position = belok[0].transform.position;
			turns[0].transform.position = belok[1].transform.position;
			if(turns[1].transform.position == belok[0].position){
				print("InPosition turns 1");
			}
		}
	}

	void OnMouseDown () {
		if(count % 2==0 )
			transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z);
		else
			transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);

		count++;
	}
}
