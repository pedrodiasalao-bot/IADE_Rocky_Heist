using UnityEngine;

public class GuardAI : MonoBehaviour
{
    [SerializeField] private Suspicion s; //get suspicion script


    public float speed = 3f;
    public float dist = 0.2f;

    private Vector2 A, B;
    //Vector3 pos;
    private Vector2 newPos;

    private bool chase = false;

    void Start()
    {
        A = new Vector2(-5, transform.position.y);
        B = new Vector2(5, transform.position.y);

        WanderTarget(A);
    }

    void Update()
    {
        //if (suspicionMeter > 5)
        //{
        //    Chase();
        //}

        Debug.Log(transform.GetChild(0).GetComponent<Suspicion>().suspicionMeter);

        // Move towards the target position
        transform.position = Vector2.MoveTowards(transform.position, newPos, speed * Time.deltaTime);

        if (chase == false) //if wandering and not chasing
        {
            //if reaching target change target
            if (Vector2.Distance(transform.position, newPos) < dist && newPos == A)
            {
                WanderTarget(B);
            }
            else if (Vector2.Distance(transform.position, newPos) < dist && newPos == B)
            {
                WanderTarget(A);
            }
        }
        else
        {

        }
        
    }

    void WanderTarget(Vector2 newPoint)
    {
        newPos = newPoint;
    }
}
