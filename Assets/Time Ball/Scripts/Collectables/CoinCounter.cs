using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CoinCounter : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        Bank.OnCoinsValueChangedEvent += OnCoinsValueChanged;
    }

    private void OnDisable()
    {
        Bank.OnCoinsValueChangedEvent -= OnCoinsValueChanged;
    }

    private void OnCoinsValueChanged(object sender, int oldValue, int newValue)
    {
        _text.text = newValue.ToString();
    }
}
