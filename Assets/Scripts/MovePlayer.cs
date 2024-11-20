using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private Vector2 moveVector;
    [SerializeField] private float speed = 4f;
    [SerializeField] private GameObject playerVisuality;

    void Awake()
    {

        anim = playerVisuality.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        moveVector = new Vector2();

    }

    void FixedUpdate()
        {
            moveVector.x = Input.GetAxis("Horizontal");
            moveVector.y = Input.GetAxis("Vertical");

            if (moveVector.x != 0 || moveVector.y != 0) anim.SetBool("isMoving", true);
            else anim.SetBool("isMoving", false);

            if (moveVector.x > 0) transform.localScale = new Vector2(1, 1);
            if (moveVector.x < 0) transform.localScale = new Vector2(-1, 1);


            rb.MovePosition(rb.position + moveVector * speed * Time.fixedDeltaTime);
        }

}
