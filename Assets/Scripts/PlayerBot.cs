using UnityEngine;

public class PlayerBot : MonoBehaviour
{

    public Rigidbody2D rb;
    public Vector2 screenSize;

    public float stepDistance = 0.5f; // How far the player steps everytime they press a key
    public float direction = 1f; // What direction they're facing (switch with S), 1 = FORWARDS || -1 = BACKWARDS
    public float stepCooldown = 0.5f; // Cooldown in-between steps
    
    private bool _nextIsD = false; // So the player can't continuously press one key and has to alternate.
    private float _nextStepTime = 0f; 
    
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

        if (Time.time < _nextStepTime) return; // If enough time hasn't passed yet, doesn't do anything
        
        if (Input.GetKeyDown(KeyCode.A) && !_nextIsD)
        {
            TakeStep();
            _nextIsD = true; // Prepares D as the next key to be pressed.
        }
        else if (Input.GetKeyDown(KeyCode.D) && _nextIsD)
        {
            TakeStep();
            _nextIsD = false; // Prepares D as the next key to be pressed.
        }
        
    
    }

    void TakeStep()
    {
        rb.position += new Vector2(direction * stepDistance, 0f); // Moves the player in the DIRECTION by STEPDISTANCE amount
        _nextStepTime = Time.time + stepCooldown; // Charges up the next step timer
    }
}
