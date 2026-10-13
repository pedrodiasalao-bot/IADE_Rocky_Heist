using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    public float inputX;
    public float inputY;

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
        inputY = Input.GetAxisRaw("Vertical");
        
        Vector3 moveDir = Vector3.Normalize(new Vector2(inputX, inputY));

        rb.linearVelocity = moveDir * speed;
        inputX = Input.GetAxisRaw("Horizontal");
    }
}

