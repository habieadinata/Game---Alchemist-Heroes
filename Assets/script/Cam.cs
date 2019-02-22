using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour {

	private Vector3 velocity;
	public float smoothTimeX;
	public float smoothTimeZ;
	public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);	
		float posZ = Mathf.SmoothDamp(transform.position.z, player.transform.position.z, ref velocity.z, smoothTimeZ);	

		transform.position = new Vector3(posX, transform.position.y, posZ);
	}
}
