using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageFiller : MonoBehaviour
{
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        DoFillAmount(0, 0.25f, 1);
    }

    public void DoFillAmount(float from, float to, float duration)
    {
        StartCoroutine(FillAmountRoutine(from, to, duration));
    }

    private IEnumerator FillAmountRoutine(float from, float to, float duration)
    {
        var passedTime = 0f;
        while (passedTime < duration)
        {
            passedTime += Time.unscaledDeltaTime;
            _image.fillAmount = Mathf.Lerp(from, to, passedTime);
            yield return null;
        }
    }
}
