using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {

	public Transform spellPoint;
	public GameObject fireSpell;
	
	void Update () {

	}

	public void spellFire()
	{
		Instantiate(fireSpell, spellPoint.position, spellPoint.rotation);
		
	}
}
