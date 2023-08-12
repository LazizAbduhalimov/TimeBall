﻿using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ICollectable>(out var collectable))
        {
            collectable.Collect();
            Destroy(other.gameObject);
        }
    }
}