using UnityEngine;

public class PlayerBot : MonoBehaviour
{
    public float speed;

    public float inputX;

    public Rigidbody2D rb;
    
    public Vector2 screenSize;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");

        Vector2 moveDir = new Vector2(inputX, 0f);
        rb.linearVelocity = moveDir * speed;
    
    }
}
