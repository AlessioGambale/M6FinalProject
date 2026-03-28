using UnityEngine;

public class LeftRightPlatform : MovingPlatform
{
    [Header("Platform Points")]
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;

    private float _time;

    protected override void Move()
    {
        _time += _speed * Time.deltaTime;
        transform.position = Vector3.Lerp(_pointA.position, _pointB.position, Mathf.PingPong(_time, 1));
    }
}
