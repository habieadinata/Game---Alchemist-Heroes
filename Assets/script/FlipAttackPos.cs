using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipAttackPos : MonoBehaviour {

	private bool facing;
	// Use this for initialization
	void Start () {
		facing = true;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 move = transform.position;
		if(Input.GetKeyDown(KeyCode.LeftArrow) && facing){
			Flip();
		}
		if(Input.GetKeyDown(KeyCode.RightArrow) && !facing){
			Flip();
		}
	}

	void Flip () 
	{
		facing = !facing;
		transform.Rotate(0f, 180f, 0f);
	}
}
