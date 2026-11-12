using UnityEngine;

public class NPC_Steering : MonoBehaviour
{
    public Rigidbody2D PlayerBody;
    
    public float speed = 3f;
    public float dist = 0.2f; //the distance to the point


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

    void WanderTarget(Vector2 newPoint)
    {
        newPos = newPoint;
    }

    void Wander()
    {
        // Move towards the target position
        transform.position = Vector2.MoveTowards(transform.position, newPos, speed * Time.deltaTime);

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
        transform.position = Vector2.MoveTowards(transform.position, playerLoc, speed * Time.deltaTime); //moving toward player
    }
}
