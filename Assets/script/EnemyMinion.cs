using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMinion : MonoBehaviour {

	public float speed;
	public float stopingDistance;
	private Transform target;
	public int health;
	public int damage;
	private bool facingRight;
	public Transform position;
	public float positionRange;
	public LayerMask isPlayer;
	private Animator animator;
	private bool isStop;

	
	void Start() {
		target = GameObject.FindGameObjectWithTag("Player")	.GetComponent<Transform>();
		animator = GetComponent<Animator>();
		facingRight = true;
		damage = 5;
		isStop = true;
		
	}

	// Update is called once per frame
	void Update () {
		if (health <= 0 )
		{
			speed = 0;
			StartCoroutine(death());
		}
		//Follow();
		Flip();
		Sight();
		animControler(isStop);
	}

	IEnumerator death () {
		animDeath(health);
		yield return new WaitForSeconds(0.68f);
		Destroy(gameObject);
	}

	public void animControler(bool stop) {
		animator.SetBool("stop", stop);
	}

	public void animDeath (int health) {
		animator.SetInteger("health", health);
	}

	public void TakeDamage(int damage)
	{
		AudioMgr.PlaySound ("Hurt");
		health -= damage;
		// for debuging only
		//Debug.Log("Damage taken : " + health);
	}

	public void TakeSpell(int damage)
	{
		AudioMgr.PlaySound ("Hurt");
		health -= damage;
		// for debuging only
		//Debug.Log("Spell taken : " + health);
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
			transform.localScale = new Vector3(2.8f,2.8f,1);
		}

		if (target.position.x > transform.position.x) {
			// face left 
			transform.localScale = new Vector3(-2.8f,2.8f,1);
		}
	}

	protected void Sight() {
		Collider2D sight = Physics2D.OverlapCircle(position.position, positionRange, isPlayer);
		if (sight) {
			Follow();
			isStop = false;
		} else {
			isStop = true;
		}

		if (sight && health <= 0) {
			isStop = true;
		}
	}

	private void OnTriggerStay2D(Collider2D other) {
		PlayerControllers player = other.GetComponent<PlayerControllers>();
		player.takeDamageEnemy(damage);
	}

	private void OnDrawGizmos() {
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(position.position, positionRange);
	}
}
