using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    [SerializeField] private AnimationParamHandler _animationParamHandler;

    [SerializeField] private SoundManager _soundManager;

    private bool _hasTriggered = false;
   
    private void OnTriggerEnter(Collider other)
    {
        if (_hasTriggered) return; 
        if (!other.CompareTag("Player")) return;
        if (!other.TryGetComponent<PlayerController>(out var playerController)) return;
        playerController.CanRun(false);
        _animationParamHandler.SetIsBuilding();
        _hasTriggered = true;
        _soundManager.PlayFinalMusic();
    }
}
