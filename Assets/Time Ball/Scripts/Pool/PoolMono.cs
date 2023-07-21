using System;
using System.Collections.Generic;
using UnityEngine;

namespace LavkaRazrabotchika
{
    public class PoolMono<T> where T : MonoBehaviour
    {
        public T Prefab { get; }
        public bool autoExpand { get; set; }

        public Transform Container { get; }

        private List<T> _pool;

        public PoolMono(T prefab, int count)
        {
            Prefab = prefab;
            Container = null;

            CreatePool(count);
        }

        public PoolMono(T prefab, int count, Transform container)
        {
            Prefab = prefab;
            Container = container;

            CreatePool(count);
        }

        private void CreatePool(int count)
        {
            _pool = new List<T>();

            for (int i = 0; i < count; i++)
            {
                CreateObject();
            }
        }

        private T CreateObject(bool isActivateByDefault = false)
        {
            var createdObjcet = UnityEngine.Object.Instantiate(Prefab, Container);
            createdObjcet.gameObject.SetActive(isActivateByDefault);
            _pool.Add(createdObjcet);
            return createdObjcet;
        }

        public bool HasFreeElement(out T element)
        {
            foreach (var mono in _pool)
            {
                if (!mono.gameObject.activeInHierarchy)
                {
                    element = mono;
                    mono.gameObject.SetActive(true);
                    return true;
                }
            }
            element = null;
            return false;
        }

        public T GetFreeElement()
        {
            if (HasFreeElement(out var element))
                return element;

            if (autoExpand)
                return CreateObject(true);

            throw new Exception($"There is no free element of type <{typeof(T)}> in pool");
        }
    }
}
