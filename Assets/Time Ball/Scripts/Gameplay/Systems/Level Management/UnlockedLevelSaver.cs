using UnityEngine;

public class UnlockedLevelSaver : MonoBehaviour
{
    public const string UNLOCKED_KEY = "LastLevel";

    public void SaveLevelAsUnlocked(Level level)
    {
        PlayerPrefs.SetInt(UNLOCKED_KEY, level.LevelIndex);
    }

    public int GetLastUnlockLevelIndex()
    {
        var levelIndex = PlayerPrefs.GetInt("LastLevel", -1);
        return ++levelIndex;
    }
}