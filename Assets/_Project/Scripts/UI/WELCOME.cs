using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WELCOME : MonoBehaviour 
{
    [SerializeField] private RectTransform [] _patrolPoints;
    [SerializeField] private float _speed;

    private int _currentPatrolIndex = 0;
    public void Update()
    {
        Movement();
    }
    private void Movement()
    {
        if (_patrolPoints.Length == 0) return;

        Vector2 currentPos = transform.position;
        Vector2 targetPos = _patrolPoints[_currentPatrolIndex].position;

        Vector2 direction = targetPos - currentPos;

        Vector2 newPos = Vector2.MoveTowards(currentPos, targetPos, _speed * Time.deltaTime);

        transform.position = newPos;

        if (Vector3.Distance(transform.position, targetPos) <= 0.05f)
        {
            _currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Length;
        }
    }
}
