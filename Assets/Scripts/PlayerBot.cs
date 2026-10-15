using UnityEngine;

public class PlayerBot : MonoBehaviour
{

    public Rigidbody2D rb;
    public Vector2 screenSize;

    public float stepDistance = 0.5f; // How far the player steps everytime they press a key
    public float direction = 1f; // What direction they're facing (switch with S), 1 = FORWARDS || -1 = BACKWARDS
    private bool nextIsD = false; // So the player can't continuously press one key and has to alternate.
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            direction = -direction; // Switches direction upon pressing the key S
        }
        
        if (Input.GetKeyDown(KeyCode.A) && !nextIsD)
        {
            rb.position += new Vector2(direction * stepDistance, 0f); // Moves the player in the DIRECTION by STEPDISTANCE amount
            nextIsD = true; // Prepares D as the next key to be pressed.
        }
        else if (Input.GetKeyDown(KeyCode.D) && nextIsD)
        {
            rb.position += new Vector2(direction * stepDistance, 0f); // Moves the player in the DIRECTION by STEPDISTANCE amount
            nextIsD = false; // Prepares D as the next key to be pressed.
        }
            
    
    }
}
