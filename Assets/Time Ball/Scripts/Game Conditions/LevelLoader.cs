using System.Collections;
using UnityEngine;
using IJunior.TypedScenes;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Level _levelToLoad;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _waitingTime;

    public void LoadLevel()
    {
        StartCoroutine(LoadLevelRoutine());
    }

    private IEnumerator LoadLevelRoutine()
    {
        _animator.SetTrigger("EndLevel");
        yield return new WaitForSecondsRealtime(_waitingTime);
        Level_1.Load(_levelToLoad);
    }
}
