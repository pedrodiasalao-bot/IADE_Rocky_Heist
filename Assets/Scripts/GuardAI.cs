using Unity.VisualScripting;
using UnityEngine;

public class GuardAI : MonoBehaviour
{
    //[SerializeField] private PlayerBot PlayerScript; //Get the PlayerBot script
    public Rigidbody2D PlayerBot;

    public double sus; //the suspicion meter
    public bool chase; //whether the guard is chasing 
    public bool invisible; //whether the player is invisible 

    //The speeds based on suspicion
    public float speedReg = 3f;
    public float speedHigh = 5f;
    public float speedChase = 4f;

    public float dist = 0.2f; //The distance to the point
    

    private Vector2 A, B; //The points the guard walks to
    private Vector2 playerLoc; //Where the player is
    private Vector2 oldP, newP;

    public float path = 5; //The distance the guard travels each way

    private Vector2 newPos;

    void Start()
    {
        //Set the points
        A = new Vector2(-path, transform.position.y);
        B = new Vector2(path, transform.position.y);

        Debug.Log(PlayerBot.position);


        WanderTarget(A);
    }

    void Update()
    {
        sus = transform.GetChild(0).GetComponent<Suspicion>().suspicionMeter;
        chase = transform.GetChild(0).GetComponent<Suspicion>().chase;




        if (chase == false)
        {
            if (sus > 50) //if suspicion high the guard will speed up
            {
                Wander(speedHigh);
            }
            else
            {
                Wander(speedReg);
            }
        }
        else
        {
            Chase(speedChase);
        }
        

    }

    void WanderTarget(Vector2 newPoint)
    {
        newPos = newPoint;
    }

    void Wander(float speed)
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

    void Chase(float speed)
    {
        //Debug.Log("chase!!!");
        playerLoc = PlayerBot.position;
        oldP = transform.position;
        transform.position = Vector2.MoveTowards(transform.position, playerLoc, speed * Time.deltaTime); //moving toward plaery
        newP = transform.position;

        //Debug.Log("OLD---->" + oldP);
        //Debug.Log("New---->" + newP);

        if (oldP.x < newP.x)
        {
            //transform.Rotate(0f, 180f, 0f);
        }
        else
        {
            //transform.Rotate(0f, 180f, 0f);
        }
    }
}
