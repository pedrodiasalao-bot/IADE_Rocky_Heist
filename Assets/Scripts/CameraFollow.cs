using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float forwardOffset = 3f;
    public float smoothTime = 0.5f;

    private Vector3 velocity = Vector3.zero;
    private PlayerBot _playerBot; // So I can reference playerbot.cs here

    [SerializeField] private Transform target;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (target != null)
        {
            _playerBot = target.GetComponent<PlayerBot>(); // Automatically sets the player as the target so I don't have to manually do that
        }
    }

    // Update is called once per frame
    void Update()
    {
        float currentDirection = (_playerBot != null) ? _playerBot.direction : 1f; // Sets currentDirection to the player's direction.
        
        Vector3 targetPosition = new Vector3(
            target.position.x + (currentDirection * forwardOffset), // The camera offset is positive when direction is 1 (so forward) and negative when direction is -1 (so backwards)
            transform.position.y, 
            -20f
        );
        
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
