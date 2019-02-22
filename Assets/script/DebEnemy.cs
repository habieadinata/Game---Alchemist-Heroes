using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DebEnemy : MonoBehaviour {

	public GameObject target = null;
	private NavMeshAgent nma = null;

	// Use this for initialization
	void Start () {
		nma = this.GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		nma.SetDestination (target.transform.position);
	}
}
