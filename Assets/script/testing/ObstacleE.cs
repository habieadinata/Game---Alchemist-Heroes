using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleE : MonoBehaviour {

    public int damage = 1;
    public float speed;

    public GameObject effect;

	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            // player takes damage
            collision.GetComponent<PlayerE>().health -= damage;
            Debug.Log(collision.GetComponent<PlayerE>().health);
            Destroy(gameObject);
        }
        
    }
}
