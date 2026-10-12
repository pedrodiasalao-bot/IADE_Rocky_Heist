using UnityEngine;
using System;
    
public class Enemy_Seek : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D _rb;
    private Transform _target;
    private Vector2 _moveDirection;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (_target)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _rb.rotation = angle;
            _moveDirection = direction;
        }
    }

    private void FixedUpdate()
    {
        if (_target)
        {
            _rb.linearVelocity = new Vector2(_moveDirection.x, _moveDirection.y) * speed;
        }
    }
}
