using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Patrol : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform[] patrollingSpots;
    [SerializeField] private float startWait;
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 _movementDirection;
    private int _randomSpot;
    private float _waitTime;
    private float _lastDirectionHorizontal;
    private float _lastDirectionVertical;
    private float _horizontal;
    private float _vertical;
    private Vector2 _lastPosition;

    private void Start()
    {
        _waitTime = startWait;
        _randomSpot = Random.Range(0, patrollingSpots.Length);
        _lastPosition = transform.position;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrollingSpots[_randomSpot].position, speed * Time.deltaTime);
        _horizontal = Mathf.Clamp(patrollingSpots[_randomSpot].position.x - _lastPosition.x, -1, 1);
        _vertical = Mathf.Clamp(patrollingSpots[_randomSpot].position.y - _lastPosition.y, -1, 1);
        
        if (Vector2.Distance(transform.position, patrollingSpots[_randomSpot].position) < 0.2f)
        {
            if (_waitTime <= 0f)
            {
                _lastPosition = patrollingSpots[_randomSpot].position;
                _randomSpot = Random.Range(0, patrollingSpots.Length);
                _waitTime = startWait;
            }
            else
            {
                _waitTime -= Time.deltaTime;
            }
        }
        
        if(Math.Abs(patrollingSpots[_randomSpot].position.x - _lastPosition.x) > Math.Abs(patrollingSpots[_randomSpot].position.y - _lastPosition.y))
            Animate(_horizontal, 0f);
        else
        {
            Animate(0f, _vertical);
        }
    }

    void Animate(float horizontal, float vertical)
    {
        anim.SetFloat("Horizontal", horizontal);
        anim.SetFloat("Vertical", vertical);
        anim.SetFloat("Speed", speed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _waitTime = 0f;
    }
}
