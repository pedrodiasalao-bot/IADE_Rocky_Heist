using UnityEngine;
using System.Collections;

public class PlayerBot : MonoBehaviour
{

    public Rigidbody2D rb;
    public Vector2 screenSize;
    
    
    public float stepDistance = 0.5f; // How far the player steps everytime they press a key
    public float direction = 1f; // What direction they're facing (switch with S), 1 = FORWARDS || -1 = BACKWARDS
    public float stepCooldown = 0.5f; // Cooldown in-between steps

    public float jumpDuration = 1.39f;
    public float jumpDistance = 2f;
    public float jumpHeight = 4f;
    public float jumpCooldown = 3f;
    public float jumpCharge = 0.78f;
    // NOTE: I timed this to each frame of the ANIM_Jump animation
    public bool isJumping = false;
    public bool isLeaning = false;
    
    private bool _nextIsD = false; // So the player can't continuously press one key and has to alternate.
    private float _nextStepTime = 0f;
    private float _nextJumpTime = 0f;
    private int _stepCounter = 0; // Counts the steps
    private int _targetSteps;

    private Animator _animator;

    //Check if player is hiding
    public InteractObj interact;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        _animator = GetComponentInChildren<Animator>();

        _targetSteps = Random.Range(5, 11); // 
    }

    // Update is called once per frame
    void Update()
    {
        if (interact.hiding) return; // if hiding can't move
        if (isJumping) return; // Does not allow the character to move if the player is jumping.
        if (isLeaning)
        {
            if (direction < 0 && Input.GetKeyDown(KeyCode.LeftArrow))
            {
                StopLeaning();
                _animator.SetTrigger("Counterbalance");
            }
            else if (direction > 0 && Input.GetKeyDown(KeyCode.RightArrow))
            {
                StopLeaning();
                _animator.SetTrigger("Counterbalance");
            }

            return; // Makes it so character can't move around when in this animation
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (isLeaning) return;
            if (isJumping) return;
            
            direction = -direction; // Switches direction upon pressing the key S
            transform.Rotate(0f, 180f, 0f); // Flips character sprite by 180 in the Y-Axis
        }

        if (Time.time < _nextStepTime) return; // If enough time hasn't passed yet, doesn't do anything

        if (Input.GetKeyDown(KeyCode.A) && !_nextIsD)
        {
            TakeStep();
            _animator.SetTrigger("LeftStep");
            _nextIsD = true; // Prepares D as the next key to be pressed.
        }
        else if (Input.GetKeyDown(KeyCode.D) && _nextIsD)
        {
            TakeStep();
            _animator.SetTrigger("RightStep");
            _nextIsD = false; // Prepares D as the next key to be pressed.
        }
        else if (Input.GetKeyDown(KeyCode.W) && Time.time >= _nextJumpTime)
        {
            StartCoroutine(JumpRoutine()); // Player is forced to wait for this to end in order to move
            return;

        }


    }


    void TakeStep()
    {
        rb.position += new Vector2(direction * stepDistance, 0f); // Moves the player in the DIRECTION by STEPDISTANCE amount
        _nextStepTime = Time.time + stepCooldown; // Charges up the next step timer
        _stepCounter++; // Adds one step to the counter

        if (_stepCounter >= _targetSteps) // if the step counter reached the random number required
        {
            isLeaning = true;
            _animator.SetTrigger("Lean");
        }
    }

    void StopLeaning()
    {
        isLeaning = false; // Returns to normal
        _stepCounter = 0; // Resets step counter so it restarts
        _targetSteps = GetNewTargetSteps(); // Randomizes the steps required again
        if (_animator != null) _animator.Play("ANIM_Idle");
    }

    int GetNewTargetSteps()
    {
        int newTarget; // Gets a new random number
        do
        {
            newTarget = Random.Range(5, 11); // Same thing as in the start function, randomizes the number
        } while (newTarget == _targetSteps);
        
        return newTarget;
    }

    private IEnumerator JumpRoutine()
    {
        isJumping = true;

        if (_animator != null)
        {
            _animator.SetTrigger("Jump"); // Makes the player jump (placed here instead of in the IF W Press due to cooldown issues)
        }
        
        yield return new WaitForSeconds(jumpCharge); // Waits for the charge animation to be done before jumping

        Vector2 startPos = rb.position; // Starts where the model is at
        Vector2 targetPos = startPos + new Vector2(direction * jumpDistance, 0f); // Target location is the start position + the jump in the current direction (negative or positive)

        float elapsedTime = 0f;
        
        // NOTE: Used AI to help with math and vectors
        while (elapsedTime < jumpDuration)
        {
            elapsedTime += Time.deltaTime;
            
            float t = Mathf.Clamp01(elapsedTime / jumpDuration);
            
            float currentX = Mathf.Lerp(startPos.x, targetPos.x, t);

            float arcOffset = 4f * jumpHeight * t * (1f - t);
            float currentY = Mathf.Lerp(startPos.y, targetPos.y, t) + arcOffset;
            
            rb.position = new Vector2(currentX, currentY);
            yield return null;
        }

        rb.position = targetPos; // Sets the player model to where it landed

        _nextJumpTime = Time.time + jumpCooldown;
        isJumping = false;
    }
}

