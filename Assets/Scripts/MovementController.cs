using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private float speed = 4f;
    public GameObject playerVisuality;
    public PlayerInput Input;
    private InputAction _move;


    void Awake()
    {

        _move = Input.actions["Move"];

        anim = playerVisuality.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
        {

            var InputMove = _move.ReadValue<Vector2>();

            if (InputMove.x != 0 || InputMove.y != 0) anim.SetBool("isMoving", true);
            else anim.SetBool("isMoving", false);

            if (InputMove.x > 0) transform.localScale = new Vector2(1, 1);
            if (InputMove.x < 0) transform.localScale = new Vector2(-1, 1);


            rb.MovePosition(rb.position + InputMove * speed * Time.fixedDeltaTime);
        }

}
