using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDevil : MonoBehaviour {
	public float speed;
	public float stopingDistance;
	private Transform target;
	public int health;
	public int damage;
	private bool facingRight;
	public Transform position;
	public float positionRange;
	public LayerMask isPlayer;

	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		facingRight = false;
		damage = 15;
		health = 120;
	}
	
	// Update is called once per frame
	void Update () {
		
		Flip();
		Sight();
	}

	public void Follow() {
		if (Vector2.Distance(transform.position, target.position) > stopingDistance){
			transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
		}
	}

	public void Flip()
	{
		facingRight = !facingRight;

		//transform.Rotate(0f, 180f, 0f);

		Vector3 theScale = transform.localScale;

		if (target.position.x > transform.position.x) {
			// face right 
			transform.localScale = new Vector3(4,4,1);
		}

		if (target.position.x < transform.position.x) {
			// face left 
			transform.localScale = new Vector3(-4,4,1);
		}
	}

	private void Sight() {
		Collider2D sight = Physics2D.OverlapCircle(position.position, positionRange, isPlayer);
		if (sight) {
			Follow();
		}
	}

	private void OnDrawGizmos() {
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(position.position, positionRange);
	}
}
