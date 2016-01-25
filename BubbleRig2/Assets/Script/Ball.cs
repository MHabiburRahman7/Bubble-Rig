using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public int speed, count=0, where;
	public Vector2 prev, now;

	void Start () {
		where = 2;
	}

	void Update(){
		if(where == 0)
			transform.Translate (Vector2.right * speed * Time.deltaTime);
		else if(where == 1)
			transform.Translate (Vector2.right * -speed * Time.deltaTime);
		else if(where == 2)
			transform.Translate (Vector2.up * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "right")
			where = 0;
		else if (col.tag == "left")
			where = 1;
		else if (col.tag == "up")
			where = 2;
		else if(col.tag =="destroyer")
			Destroy(this.gameObject);
	}
}
