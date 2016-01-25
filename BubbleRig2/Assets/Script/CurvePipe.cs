using UnityEngine;
using System.Collections;

public class CurvePipe : MonoBehaviour {

	public int count = 0;
	public int stat = 0;
	
	void OnMouseDown () {
		if (count % 2 == 0)
			transform.localScale = new Vector3(transform.localScale.x , transform.localScale.y ,transform.localScale.z);
		else
			transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y ,transform.localScale.z);
		count++;
	}
}
