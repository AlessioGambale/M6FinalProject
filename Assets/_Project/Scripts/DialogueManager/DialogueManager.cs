using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    [Header("UI Dialogue")]
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private TextMeshProUGUI _speakerText;

    [Header("Events")]
    [SerializeField] private UnityEvent _onDialogueStart;
    [SerializeField] private UnityEvent _onDialogueEnd;

    [Header("Dialogue Content")]
    [SerializeField] private string[] _speakers;
    [SerializeField] private string[] _dialogueTexts;
    [SerializeField] private float[] _durations; 

    private int _currentLineIndex;
    private float _lineTimer;
    private bool _dialogueActive = false;

    public void StartDialogue()
    {
        _currentLineIndex = 0;
        _dialogueActive = true;
        _onDialogueStart.Invoke();
        ShowCurrentLine();
    }

    private void Update()
    {
        if (!_dialogueActive) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            SkipDialogue();
            return;
        }

        if (HasCurrentLineFinished())
        {
            NextLine();
        }
    }

    private bool HasCurrentLineFinished()
    {
        return Time.time - _lineTimer >= _durations[_currentLineIndex]; 
    }

    private void ShowCurrentLine()
    {
        _lineTimer = Time.time;

        if (_speakerText) _speakerText.text = _speakers[_currentLineIndex];
        if (_dialogueText) _dialogueText.text = _dialogueTexts[_currentLineIndex];
    }

    private void NextLine()
    {
        _currentLineIndex++;

        if (_currentLineIndex >= _dialogueTexts.Length)
        {
            _dialogueActive = false;
            _onDialogueEnd.Invoke();
            return;
        }
        ShowCurrentLine();
    }
    private void SkipDialogue()
    {
        _currentLineIndex = _dialogueTexts.Length;
        _dialogueActive = false;
        _onDialogueEnd.Invoke();
        SoundManager.Instance.StopDialogue();
    }
}