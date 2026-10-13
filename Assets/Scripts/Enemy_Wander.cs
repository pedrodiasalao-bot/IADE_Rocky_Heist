using UnityEngine;

public class Enemy_Wander : MonoBehaviour
{
    //public float wanderRadius = 5f;
    public float speed = 2f;
    public float dist = 0.2f;

    float x;
    float y;
    float z;
    //Vector3 pos;
    private Vector2 newPos;

    void Start()
    {
        SetNewTarget();
    }

    void Update()
    {
        // Move towards the target position
        transform.position = Vector2.MoveTowards(transform.position, newPos, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, newPos) < dist)
        {
            SetNewTarget();
        }

        //Debug.Log("pos --->" + transform.position);
        //Debug.Log("target --->" + newPos);
    }

    void SetNewTarget()
    {
        x = Random.Range(-5, 6);
        y = Random.Range(-5, 6);
        z = 0;

        newPos = new Vector3(x, y, z);
    }
}
