using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGore : MonoBehaviour {

	public float speed;
	private Animator anim;
	public float stopingDistance;
	private Transform target;
	private bool facingRight;
	public Transform position;
	public float positionRange;
	public LayerMask isPlayer;
	private bool isStop;
	public int damage;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player")	.GetComponent<Transform>();
		anim = GetComponent<Animator> ();
		facingRight = true;
		damage = 25;
	}
	
	// Update is called once per frame
	void Update () {
		Flip();
		Sight();
		animControl(isStop);
	}

	public void animControl (bool stop) {
		anim.SetBool ("stop", stop);
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


		if (target.position.x < transform.position.x) {
			// face right 
			transform.localScale = new Vector3(-2.8f,2.8f,1);
		}

		if (target.position.x > transform.position.x) {
			// face left 
			transform.localScale = new Vector3(2.8f,2.8f,1);
		}
	}

	public void Sight() {

		//if (sight) {
			//Follow();
			//isStop = false;
		//} else {
			//isStop = true;
		//}

	}

	private void OnTriggerStay2D(Collider2D other) {
		PlayerControllers player = other.GetComponent<PlayerControllers>();
		player.takeDamageEnemy(damage);
	}

	private void OnDrawGizmos() {
		Gizmos.color = Color.blue;
		//Gizmos.DrawWireSphere(position.position, positionRange);
	}
}
