using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private Vector2 moveVector;

    [SerializeField] private float speed = 4f;

    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        moveVector = new Vector2();

    }

    void FixedUpdate()
        {
            moveVector.x = Input.GetAxis("Horizontal");
            moveVector.y = Input.GetAxis("Vertical");
            rb.MovePosition(rb.position + moveVector * speed * Time.fixedDeltaTime);
        }

}
