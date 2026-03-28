using UnityEngine;

public class SecretPassages : MonoBehaviour
{
    [SerializeField] int _requieredCoins;

    private void Update()
    {
        ActivateSecretPassage();
    }
    private void ActivateSecretPassage()
    {
        if (!CoinManager.Instance.HasReachedCoins(_requieredCoins)) return;
        GetComponent<Rigidbody>().isKinematic = false;

    }
}
