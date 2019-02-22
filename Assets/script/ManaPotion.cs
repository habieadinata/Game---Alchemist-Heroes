using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotion : MonoBehaviour {

	public int Mana = 10;


	private void OnTriggerEnter2D(Collider2D other) {
		PlayerControllers statPlayer = other.GetComponent<PlayerControllers>();
		AudioMgr.PlaySound ("Drain");
		statPlayer.getMana(Mana);
		Destroy(gameObject);
	}
}
