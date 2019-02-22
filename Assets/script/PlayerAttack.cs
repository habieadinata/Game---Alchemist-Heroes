using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	private Character character;

	private float timeBtwAttack;
	public float startTimeBtwAttack;
	public Transform attackPos;
	public float attackRange;
	public LayerMask isEnemies;
	public int damage;
	private bool attack;
	private Animator anim;


	// spell
	public GameObject fireSpell;
	public Transform SpellPosition;


	// Use this for initialization
	void Start () {
		attack = true;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Attack();
		
	}
	public void Attack()
    {
		
        if (timeBtwAttack <= 0)
		{
			if (Input.GetKeyDown(KeyCode.A) && attack)
			{
				AudioMgr.PlaySound ("Hit");
				anim.SetBool("attack", true);
				Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, isEnemies);
				for (int i = 0; i < enemiesToDamage.Length; i++)
				{
					enemiesToDamage[i].GetComponent<EnemyMinion>().TakeDamage(damage);
				}

				timeBtwAttack = startTimeBtwAttack;
			} else
			{
				anim.SetBool("attack", false);
			}
		} else {
			timeBtwAttack -= Time.deltaTime;
		}
    }

	private void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(attackPos.position, attackRange);
	}
}

