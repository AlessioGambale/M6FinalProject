using UnityEngine;

public class SecretPassages : MonoBehaviour
{
    [SerializeField] int _requieredCoins;
    [SerializeField] CoinManager _coinManager;

    private void Update()
    {
        ActivateSecretPassage();
    }
    private void ActivateSecretPassage()
    {
        if (!_coinManager.HasReachedCoins(_requieredCoins)) return;
        GetComponent<Rigidbody>().isKinematic = false;

    }
}
