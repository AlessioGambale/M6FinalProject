using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("SFX")]
    [SerializeField] private AudioClip _knivesSound;
    [SerializeField] private AudioClip _balloonSound;
    [SerializeField] private AudioClip _panSound;
    [SerializeField] private AudioClip _basicCoinSound;
    [SerializeField] private AudioClip _doubleCoinSound;
    [SerializeField] private AudioClip _healthCoinSound;
    [SerializeField] private AudioClip _timeCoinSound;
    [SerializeField] private AudioClip _shootSound;
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _stunSound;
    [SerializeField] private AudioSource _sfxSource;

    [Header("Music")]
    [SerializeField] private AudioClip _finalMusic;
    [SerializeField] private AudioClip _introMusic;
    [SerializeField] private AudioClip _loopMusic;
    [SerializeField] private AudioSource _musicSource;

    [Header("Dialogues")]
    [SerializeField] private AudioClip _firstDialogue;
    [SerializeField] private AudioClip _secondDialogue;
    [SerializeField] private AudioSource _dialogueSource;

    private float _introTimer = 0f;
    private bool _hasLoopStart = false;

    public static SoundManager Instance { get; private set; }
    private void Awake ()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private bool HasIntroFinished()
    {
        return Time.time - _introTimer >= _introMusic.length -1f;
    }
    private void Start()
    {
        _musicSource.clip = _introMusic;
        _musicSource.Play();
    }
    private void Update()
    {
        if (_hasLoopStart) return;
        if (HasIntroFinished())
        {
            _hasLoopStart = true;
            _musicSource.clip = _loopMusic;
            _musicSource.Play();
        }
    }
#region InteractablesSounds
    
    public void PlayBalloon()
    {
        _sfxSource.PlayOneShot(_balloonSound);
    }
    public void PlayPan()
    {
        _sfxSource.PlayOneShot(_panSound);
    }

    public void PlayStun()
    {
        _sfxSource.PlayOneShot(_stunSound);
    }
    #endregion

#region CoinsSounds
    public void PlayBasicCoin()
    {
        _sfxSource.PlayOneShot(_basicCoinSound);
    }
    public void PlayDoubleCoin()
    {
        _sfxSource.PlayOneShot(_doubleCoinSound);
    }
    public void PlayHealthCoin()
    {
        _sfxSource.PlayOneShot(_healthCoinSound);
    }
    public void PlayTimeCoin()
    {
        _sfxSource.PlayOneShot(_timeCoinSound);    
    }
    #endregion

    public void PlayShoot()
    {
         _sfxSource.PlayOneShot(_shootSound);
    }
    
    public void PlayJump()
    {
        _sfxSource.PlayOneShot(_jumpSound);
    }
#region Music
    public void PauseLoopMusic()
    {
        _musicSource.Pause();
    } 

    public void ResumeLoopMusic()
    {
        _musicSource.UnPause();
    }

    public void PlayFinalMusic() 
    {
         _musicSource.clip = _finalMusic;
         _musicSource.Play();
    }
    #endregion
#region Dialogues
    public void PlayFirstDialogue()
    {
        _dialogueSource.PlayOneShot(_firstDialogue);
    }

    public void PlaySecondDialogue()
    {
        _dialogueSource.PlayOneShot(_secondDialogue);
    }

    public void StopDialogue()
    {
        _dialogueSource.Stop();
    }
#endregion
}

