using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour {

	public int Health = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other) {
		PlayerControllers statPlayer = other.GetComponent<PlayerControllers>();
		AudioMgr.PlaySound ("Pick");
		statPlayer.getHealth(Health);
		Destroy(gameObject);
	}
}
