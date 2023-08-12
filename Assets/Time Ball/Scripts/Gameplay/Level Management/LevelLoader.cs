using System;
using System.Collections;
using UnityEngine;
using IJunior.TypedScenes;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Level[] _levelsToLoad;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _waitingTime;

    private void Awake()
    {
        if (_levelsToLoad.Length < 1)
            throw new NullReferenceException($"No levels to load on {name}");
    }

    public void LoadLevel()
    {
        StartCoroutine(LoadLevelRoutine());
    }

    private IEnumerator LoadLevelRoutine()
    {
        _animator.SetTrigger("EndLevel");
        yield return new WaitForSecondsRealtime(_waitingTime);
        var lastLevel = GetLastUnlockLevel();
        Level_1.Load(lastLevel);
    }

    private Level GetLastUnlockLevel()
    {
        var levelIndex = PlayerPrefs.GetInt("LastLevel", 0);
        return _levelsToLoad[levelIndex];
    }
}
