using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _livesText;

    public void UpdateLivesUI(int lives)
    {
        _livesText.text = $"{lives}";
    }
}
