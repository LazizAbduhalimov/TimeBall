using UnityEngine;

public class TragectoryRendererSwithcer : MonoBehaviour
{
    [SerializeField] private BallContoller _ballContoller;

    private void Update()
    {
        if (!_ballContoller.gameObject.activeInHierarchy && gameObject.activeInHierarchy)
            gameObject.SetActive(false);

        if (_ballContoller.gameObject.activeInHierarchy && !gameObject.activeInHierarchy)
            gameObject.SetActive(true);
    }
}