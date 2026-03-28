using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private bool _targetSetActive;
    public void DisableWall()
    {
        _target.SetActive(false);
    }
}
