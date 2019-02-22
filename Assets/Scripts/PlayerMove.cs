using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    [SerializeField]
    private float speed;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Vector2 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {

        //Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //moveVelocity = moveInput.normalized * speed;
        //rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        rb.velocity = direction.normalized * speed;

        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
    }

    
}
