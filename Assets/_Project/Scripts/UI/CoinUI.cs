using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinText;

    public void UpdateCoinsUI(int coins)
    {
        _coinText.text = $"{coins}";
    }
}
