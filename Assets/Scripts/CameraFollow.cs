using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float forwardOffset = 3f;
    public float smoothTime = 0.5f;

    private Vector3 velocity = Vector3.zero;
    private float direction = 1f; // Same as PlayerBot direction

    [SerializeField] private Transform target;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            direction = -direction;
        }
        
        Vector3 targetPosition = new Vector3(
            target.position.x + (direction * forwardOffset), // The camera offset is positive when direction is 1 (so forward) and negative when direction is -1 (so backwards)
            transform.position.y, 
            -10f
        );
        
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
