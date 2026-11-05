using UnityEngine;

public class GuardAI : MonoBehaviour
{
    public double sus;

    public float speedReg = 3f;
    public float speedHigh = 6f;
    public float dist = 0.2f;

    public float path = 5;

    private Vector2 A, B;
    //Vector3 pos;
    private Vector2 newPos;

    private bool chase = false;

    void Start()
    {
        A = new Vector2(-path, transform.position.y);
        B = new Vector2(path, transform.position.y);

        WanderTarget(A);
    }

    void Update()
    {
        sus = transform.GetChild(0).GetComponent<Suspicion>().suspicionMeter;


        if (sus > 5) //if suspicion high the guard will speed up
        {
            Wander(speedHigh);
        }
        else
        {
            Wander(speedReg);
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

        if (chase == false) //if wandering and not chasing
        {
            //if reaching target change target
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
    }
}
