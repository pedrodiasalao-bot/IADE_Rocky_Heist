using System;
using UnityEngine;

public class Enemy_Pursue : MonoBehaviour
{
    public float speed = 5f;
    public float maxPredictionTime = 1f;
    
    private Rigidbody2D _rb;
    private Transform _target;
    private Rigidbody2D _targetRb;
    private Vector2 _moveDirection;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player)
        {
            _target = player.transform;
            _targetRb = _target.GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_target)
        {
            float distance = Vector2.Distance(transform.position, _target.position);
            float predictionTime = Mathf.Min(distance / speed, maxPredictionTime);
            
            Vector2 targetVelocity = _targetRb != null ? _targetRb.linearVelocity : Vector2.zero;
            Vector3 predictedPosition = _target.position + (Vector3)(targetVelocity * predictionTime);

            _moveDirection = (predictedPosition - transform.position).normalized;
            
            float angle = Mathf.Atan2(_moveDirection.y, _moveDirection.x) * Mathf.Rad2Deg;
            _rb.rotation = angle;
        }
    }

    private void FixedUpdate()
    {
        if (_target)
        {
            _rb.linearVelocity = _moveDirection * speed;
        }
    }
}
