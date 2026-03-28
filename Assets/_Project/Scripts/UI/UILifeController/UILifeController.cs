using UnityEngine;
using UnityEngine.UI;

public class UI_LifeController : MonoBehaviour
{
    [SerializeField] private Image _healthBarFill;

    public void UpdateLifeBarUI(int currentHealth , int maxHealth)
    {
        _healthBarFill.fillAmount = (float) currentHealth / maxHealth;
    }
}