using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Image))]
public class UIImageAlphaController : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] private float _endValue;
    [SerializeField] private float _duration;
    [SerializeField] private bool _isAlhaZeroWhenInactive;

    private Image _image;

    private void Awake()
    {
        _image.DOFade(0, 0);
        _image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _image.DOFade(_endValue, _duration);
    }

    private void OnDisable()
    {
        if (_isAlhaZeroWhenInactive)
            _image.DOFade(0, 0);
    }
}
