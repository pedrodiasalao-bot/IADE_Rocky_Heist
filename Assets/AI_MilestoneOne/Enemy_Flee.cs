using UnityEngine;

public class Enemy_Flee : MonoBehaviour
{
    public float dist = 5f;
    public float speed = 2f;

    // Start is calle[d once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var playerPos = GameObject.Find("Player").transform.position;

        if (Vector2.Distance(transform.position, playerPos) < dist)
        {
            Vector3 fleeDir = (transform.position - playerPos).normalized;
            Vector3 targetPos = transform.position + fleeDir;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);


            if (Vector2.Distance(transform.position, fleeDir) <= 0.5)
            {
                UnityEngine.Debug.LogWarning("flee ---" + fleeDir);
                UnityEngine.Debug.LogWarning("p ---" + playerPos);
            }
        }

    }
}
