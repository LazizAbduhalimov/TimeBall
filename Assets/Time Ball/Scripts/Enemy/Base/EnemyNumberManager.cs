using UnityEngine;

public class EnemyNumberManager : MonoBehaviour
{
    private int _enemiesLeft;

    private void Start()
    {
        var enemies = FindObjectsOfType<EnemyBase>();
        _enemiesLeft = enemies.Length;
        foreach (var enemy in enemies)
        {
            enemy.OnEnemyDieEvent += OnEnemyDie;
        }
    }

    private void OnEnemyDie()
    {
        _enemiesLeft--;

        if (_enemiesLeft < 1)
        {
            Debug.Log("You win!");
        }
    }
}