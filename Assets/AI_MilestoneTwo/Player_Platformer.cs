using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player_Platformer : MonoBehaviour
{
    // variables to move
    private Rigidbody2D rb;
    private float moveX;
    private Vector2 move;
    private float moveSpeed = 5f;

    //variables to jump
    private float JumpForce = 10f;
    public LayerMask GroundLayer;
    public BoxCollider2D GroundCollider;
    public bool OnGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        OnGround = true;
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space) && OnGround)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce);
            OnGround = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(GroundLayer == (1 << other.gameObject.layer))
        {
            OnGround = true;
        }
    }

    void FixedUpdate()
    {
        move = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);
        rb.linearVelocity = move;
    }
}
