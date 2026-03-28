using UnityEngine;

public class PathPlatform : MovingPlatform
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private bool _canLoop;
    [SerializeField] private float _rotateSpeed = 2f;

    private int _currentIndex = 0;

    protected override void Move()
    {
        if (_waypoints.Length == 0) return;

        Movement();
        RotateTowardsNext();
    }

    private void IndexIncrese()
    {
        if (_canLoop)
        {
            _currentIndex = (_currentIndex + 1) % _waypoints.Length;
        }
        else
        {
            if (_currentIndex < _waypoints.Length - 1)
            {
                _currentIndex++;
            }
        }
    }

    private void Movement()
    {
        Vector3 targetPosition = _waypoints[_currentIndex].position;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.fixedDeltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            IndexIncrese();
        }
    }

    private void RotateTowardsNext()
    {
        Vector3 direction = _waypoints[_currentIndex].position - transform.position;

        if (direction == Vector3.zero) return;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotateSpeed * Time.fixedDeltaTime);
    }
}
