using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour {

	public int coin;



	public void OnTriggerEnter2D(Collider2D other) {
		AudioMgr.PlaySound ("Coin");
		ScoreCoin.coinAmount += 1;
		Destroy(gameObject);
		
	}
}
