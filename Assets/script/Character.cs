using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Character : MonoBehaviour {

	[SerializeField]
	private float speed;
	protected Vector2 direction;
	private bool facingRight;
	private Animator anim;
	private Rigidbody2D myRigidbody;

	// Use this for initialization
	protected virtual void Start () {
		facingRight = true;
		myRigidbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		Anim (horizontal, vertical); 
		Flip (horizontal); 
	}

	private void FixedUpdate(){
		Move ();
	}

	public void Move()
	{
		myRigidbody.velocity = direction.normalized * speed;
	}

	public void Anim(float horizontal, float vertical)
	{
		anim.SetFloat ("speed", Mathf.Abs (horizontal));
		anim.SetFloat ("y", Mathf.Abs (vertical));
	}

    

	// flip character
	public void Flip(float horizontal)
	{
		facingRight = !facingRight;

		//transform.Rotate(0f, 180f, 0f);

		Vector3 theScale = transform.localScale;
		

		if (horizontal < 0 && facingRight) {
			theScale.x = -4;
			transform.localScale = theScale;
			
		}

		if (horizontal > 0 && !facingRight) {
			theScale.x = 4;
			transform.localScale = theScale;
		}
	}

	
}
