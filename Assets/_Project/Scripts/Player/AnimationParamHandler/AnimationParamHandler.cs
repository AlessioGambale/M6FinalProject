using UnityEngine;

public class AnimationParamHandler : MonoBehaviour
{
    [SerializeField] private string _isBuildingName = "isBuilding";
    [SerializeField] private string _forwardName = "Forward";
    [SerializeField] private string _floatingName = "Floating";

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    public void SetForward(float speed)
    {
        _animator.SetFloat(_forwardName , speed);
    }
    public void SetIsBuilding()
    {
        _animator.SetTrigger(_isBuildingName);
    }
    public void Floating()
    {
        _animator.SetTrigger(_floatingName);
    }
}
