using UnityEngine;
using UnityEngine.Events;

public class PlayerRespawn : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private UnityEvent<int> _onLifeLost;
    [SerializeField] private UnityEvent _onLivesEnded;
    [SerializeField] private PlayerController _playerController;

    [Header("Lives Settings")]
    [SerializeField] private int _maxLives;
    [SerializeField] private CheckPointManager _checkPointManager;

    private LifeController _lifeController;
    private int _currentLives;

    public int CurrentLives => _currentLives;
    private void Start()
    {
        _currentLives = _maxLives;
    }
    private void Awake()
    {
        _lifeController = GetComponent<LifeController>();
    }
    public void Respawn()
    {
        if(!_checkPointManager.HasCheckPoint()) return;
        _currentLives--;

        _onLifeLost.Invoke(_currentLives);
        if ( _currentLives <= 0 )
        {
            _onLivesEnded.Invoke();
        }
        transform.position = _checkPointManager.GetCheckPoint();
        _lifeController.RestoreFullHp();
        _playerController.ResetMoveAndRotate();
    }
}
