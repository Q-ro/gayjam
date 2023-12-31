using System;
using UnityEngine;

public class TableDropObjectSpawner : MonoBehaviour
{
    public static Action<GameObject> OnSpawnDropObject;

    void Start()
    {
        OnSpawnDropObject += SpawnObject;
    }

    private void SpawnObject(GameObject objectToSpawn)
    {
        var go = Instantiate(objectToSpawn);
        go.transform.position = this.transform.position;
    }
}
