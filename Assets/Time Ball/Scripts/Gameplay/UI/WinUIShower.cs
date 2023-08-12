using UnityEngine;

public class WinUIShower : MonoBehaviour
{
    [SerializeField] private GameObject _UIObjectToShow;

    private void ShowUI()
    {
        _UIObjectToShow.gameObject.SetActive(true);
    }
}
