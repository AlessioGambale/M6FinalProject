using System.Collections;
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
    private bool _dialogueActive = false;
    private Coroutine _dialogueCoroutine;

    public void StartDialogue()
    {
        if (_dialogueActive) return;

        _currentLineIndex = 0;
        _dialogueActive = true;
        _onDialogueStart.Invoke();

        _dialogueCoroutine = StartCoroutine(RunDialogue());
    }

    private IEnumerator RunDialogue()
    {
        while (_currentLineIndex < _dialogueTexts.Length)
        {
            ShowCurrentLine();

            float timer = 0f;
            bool skipped = false;

            while (timer < _durations[_currentLineIndex])
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    skipped = true;
                    break;
                }
                timer += Time.deltaTime;
                yield return null;
            }

            if (skipped)
            {
                SkipDialogue();
                SoundManager.Instance.StopDialogue();
                yield break;
            }

            _currentLineIndex++;
        }

        EndDialogue();
    }

    private void ShowCurrentLine()
    {
        if (_speakerText) _speakerText.SetText(_speakers[_currentLineIndex]);
        if (_dialogueText) _dialogueText.SetText(_dialogueTexts[_currentLineIndex]);
    }

    private void SkipDialogue()
    {
        if (_dialogueCoroutine != null)
            StopCoroutine(_dialogueCoroutine);

        _currentLineIndex = _dialogueTexts.Length;
        EndDialogue();
    }

    private void EndDialogue()
    {
        _dialogueActive = false;
        _onDialogueEnd.Invoke();
    }
}