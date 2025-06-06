using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 8.0f;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            // 左、右
            direction.x = Input.GetAxisRaw("Horizontal");

            // 上、下
            direction.y = Input.GetAxisRaw("Vertical");
        }
    }

    private void FixedUpdate()
    {
        Vector2 dist = direction * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + dist);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Map")
        {
            Debug.Log("Map Hit");
            StartCoroutine("WaitTime");

        }
    }
}
