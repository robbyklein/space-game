using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameObjectPool {
    [SerializeField] GameObject prefab;
    [SerializeField] int initialAmount = 20;
    [SerializeField] int bufferAmount = 10;
    [SerializeField] Transform container;

    Stack<GameObject> pool = new Stack<GameObject>();

    void Awake() {
        AddToPool(initialAmount);
    }

    public GameObject Get(bool enableOnGet = true) {
        if (pool.Count < bufferAmount) {
            AddToPool(initialAmount);
        }

        GameObject go = pool.Pop();
        if (enableOnGet) go.SetActive(true);

        return go;
    }

    public void Return(GameObject go, bool disableOnReturn = true) {
        if (disableOnReturn) go.SetActive(false);
        pool.Push(go);
    }

    void AddToPool(int amount) {
        for (int i = 0; i < amount; i++) {
            GameObject go = UnityEngine.GameObject.Instantiate(prefab, container);
            Return(go);
        }
    }
}
