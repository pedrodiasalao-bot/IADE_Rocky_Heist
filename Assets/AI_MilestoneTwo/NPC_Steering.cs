using UnityEngine;

public class NPC_Steering : MonoBehaviour
{
    public Rigidbody2D PlayerBody;
    
    public float speed = 3f;
    public float dist = 0.2f; //the distance to the point

    private Rigidbody2D rb;
    public float maxForce = 20f; // So the NPC doesn't go too fast
    public float slowingRadius = 1.5f; // Arrive Behaviour (from first milestone)

    //patrolling
    private Vector2 A, B; // patrolling waypoint
    private Vector2 playerLoc; //Where the player is
    private Vector2 oldP, newP;

    public float path = 5; //The distance the guard travels each way
    private Vector2 newPos;

    private bool chase; //whether chasing 
    private bool lostChase = false;
    private float time = 5;


    public void OnTriggerEnter2D(Collider2D other) //checks the collision is happened
    {
        //Debug.Log("-----------HELLO-----------");
        if (other.CompareTag("Player")) //found player
        {
            Debug.Log("Found you!");
            chase = true;

        }
    }

    public void OnTriggerExit2D(Collider2D other) //checks the collision stopped happening
    {
        //Debug.Log("-----------BYE-----------");
        if (other.CompareTag("Player")) //lost player
        {
            Debug.Log("Lost you!");
            lostChase = true;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Set the points
        A = new Vector2(-path, transform.position.y);
        B = new Vector2(path, transform.position.y);
        WanderTarget(A);
    }

    void Update()
    {

        if (chase == false)
        {
            Wander();
        }
        else
        {
            Chase();
            time -= Time.deltaTime;
            Debug.Log(time);
            if (time <= 0)
            {
                chase = false;
                time = 5;
            }

        }


    }

    void Steering(Vector2 target)
    {
        float distance = Mathf.Abs(target.x - transform.position.x);

        float desiredSpeed = speed;
        if (distance < slowingRadius) // Arrive behavior, makes him slow down slightly when approaching target
        {
            desiredSpeed = speed * (distance / slowingRadius);
        }
        
        float directionX = Mathf.Sign((target.x - transform.position.x));
        float desiredVelocityX = directionX * desiredSpeed;
        
        float steeringForceX = desiredVelocityX - rb.linearVelocity.x;
        
        steeringForceX = Mathf.Clamp(steeringForceX, -maxForce, maxForce); // setting a limit to the force the NPC can steer at
        
        rb.AddForce(new Vector2(steeringForceX, 0f));
    }

    void WanderTarget(Vector2 newPoint)
    {
        newPos = newPoint;
    }

    void Wander()
    {
        // Move towards the target position
       // REPLACED WITH THE FUNCTION ABOVE: transform.position = Vector2.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
       Steering(newPos);

        if (Vector2.Distance(transform.position, newPos) < dist && newPos == A)
        {
            WanderTarget(B);
            transform.Rotate(0f, 180f, 0f);
        }
        else if (Vector2.Distance(transform.position, newPos) < dist && newPos == B)
        {
            WanderTarget(A);
            transform.Rotate(0f, 180f, 0f);
        }
    }

    void Chase()
    {
        //Debug.Log("chase!!!");
        playerLoc = PlayerBody.position;
        Steering(playerLoc);
    }
}
