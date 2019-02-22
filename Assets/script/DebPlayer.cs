using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebPlayer : MonoBehaviour {

	public float moveSpeed = 10.0f;
	public float turnSpeed = 45.0f;
	public Vector3 dir;

	
	// Update is called once per frame
	void Update () {
		dir = Vector3.zero;
		if (Input.GetKey(KeyCode.UpArrow) ==  true) {
			this.transform.Translate (new Vector3 (0, 0, moveSpeed * Time.deltaTime)) ;
		}
		else if (Input.GetKey(KeyCode.DownArrow) ==  true) {
			this.transform.Translate (new Vector3 (0, 0, -moveSpeed * Time.deltaTime));
		}
		else if (Input.GetKey(KeyCode.LeftArrow) ==  true) {
			this.transform.Translate (new Vector3 (-moveSpeed * Time.deltaTime, 0,  0));
		}
		else if (Input.GetKey(KeyCode.RightArrow) ==  true) {
			this.transform.Translate (new Vector3 (moveSpeed * Time.deltaTime, 0, 0));
		}
	}
}
