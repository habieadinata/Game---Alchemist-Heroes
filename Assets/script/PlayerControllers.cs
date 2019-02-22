using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllers : Character {

	[SerializeField]
	private Stat Health;

	[SerializeField]
	private Stat Mana;

	
	private float initHealth = 100;
	private float initMana = 50;

	private Spell spell;

	private float timer = 0.0f;
	private float cooldown = 0.7f;

	public GameObject LoseUI;

	protected override void Start () {
		Health.Init (initHealth, initHealth);	
		Mana.Init (initMana, initMana);
		base.Start ();
		spell = GetComponent<Spell>();
		LoseUI.SetActive (false);
	}

	// Update is called once per frame
	protected override void Update () {

		GetInput ();
		base.Update ();

	}

	public void takeDamageEnemy(int damage){
		// Health.MycurrentValue -= damage;
		// Debug.Log(Health.MycurrentValue);

		if(timer > cooldown) { 
			AudioMgr.PlaySound ("Hurt2");
            Health.MycurrentValue -= damage;
			Debug.Log(Health.MycurrentValue);
			timer = 0;
        }

        if(timer < cooldown + 1) // Add some leaniency for inaccurate floating points.
            timer += Time.deltaTime;

		if(Health.MycurrentValue <= 0) {
			//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			AudioMgr.PlaySound ("Lose");
			LoseUI.SetActive(true);
			Time.timeScale = 0f;
			
		}
	}

	public void Restart () {
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

	public void MainMenu () {
		SceneManager.LoadScene (0);
	}

	public void getHealth (int healthPotion) {
		Health.MycurrentValue += healthPotion;
	}

	public void getMana (int manaPotion) {
		Mana.MycurrentValue += manaPotion;
	}

	// input untuk gerak
	public void GetInput()
	{
		/// DEBUGING ONLY

		if(Input.GetKeyDown(KeyCode.Z) && Mana.MycurrentValue > 0){
			spell.spellFire();
			AudioMgr.PlaySound ("Explosion");
			// Health.MycurrentValue -= 10;
			Mana.MycurrentValue -= 10;
		}

		direction = Vector2.zero;
		if(Input.GetKey(KeyCode.UpArrow))
		{
			direction += Vector2.up;
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			direction += Vector2.down;
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			direction += Vector2.left;
		}
		if(Input.GetKey(KeyCode.RightArrow))
		{
			direction += Vector2.right;
		}
	}

	
}
