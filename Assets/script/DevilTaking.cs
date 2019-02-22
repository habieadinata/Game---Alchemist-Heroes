using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilTaking : EnemyMinion {

	private Animator animator;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0 )
		{
			speed = 0;
			StartCoroutine(deathDevil());
		}
	}

	IEnumerator deathDevil () {
		aniDeath(health);
		yield return new WaitForSeconds(0.68f);
		Destroy(gameObject);
	}

	public void aniDeath (int health) {
		animator.SetInteger("health", health);
	}

	// public void TakeDamage(int damage)
	// {
	// 	health -= damage;
	// 	// for debuging only
	// 	//Debug.Log("Damage taken : " + health);
	// }
}
