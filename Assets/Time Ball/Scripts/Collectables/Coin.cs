using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    [SerializeField] private ParticleSystem _collectionEffect;
    [SerializeField] private int amount = 1;

    public void Collect()
    {
        Bank.AddCoins(this, amount);
        CreateEffect();
    }

    private void CreateEffect()
    {
        Instantiate(_collectionEffect, transform.position, Quaternion.identity);
    }
}
