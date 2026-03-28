using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private UnityEvent<float> _onTimeChanged;
    [SerializeField] private UnityEvent _onTimeEnded;

    [SerializeField] private float _timerDuration = 60f;

    private bool _hasTimeStopped = false;
    public float TimerDuration { get => _timerDuration;  set => _timerDuration = value; }
    public float RemainingTime { get; private set; }
    public void SetTime(float time)
    {
       RemainingTime = Mathf.Max(time, 0);
       RemainingTime = time;
    }
    public void AddTime(float amount)
    {
        SetTime(RemainingTime + amount);
    }
    private void Start()
    {
        StartTimer(_timerDuration);
    }
    private void StartTimer (float duration)
    {
        RemainingTime = duration;
    }
    public void StopTime()
    {
        _hasTimeStopped = true;
    }
    public void RestartTime()
    {
        _hasTimeStopped = false;
    }
    
    private void Update()
    {
        if (_hasTimeStopped) return;
        UpdateTimer();
    }
    private void UpdateTimer ()
    {
        if (RemainingTime <= 0) return;
        RemainingTime -= Time.deltaTime;
        _onTimeChanged.Invoke(RemainingTime);

        if (RemainingTime <= 0 )
        {
            RemainingTime = 0f;
            _onTimeEnded.Invoke();
        }
    }
   
}
