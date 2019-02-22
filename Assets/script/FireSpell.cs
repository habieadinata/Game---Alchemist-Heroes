using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpell : MonoBehaviour {

	public float speed = 10f;
	public Rigidbody2D rb;
	public int damage = 40;

	void Start () {
		rb.velocity = transform.right * speed;
	}

	void Update() {
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(-1,-1));
		if (transform.position.x > max.x)
		{
			Destroy(gameObject);
		}
		if (transform.position.x < min.x)
		{
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		EnemyMinion enemy = other.GetComponent<EnemyMinion>();
		enemy.TakeSpell(damage);
		Destroy(gameObject);
	}

}
