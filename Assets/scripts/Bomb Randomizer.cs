using System.Collections.Generic;
using UnityEngine;

public class BombRandomizer : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float spawnInterval;
    [SerializeField] private int maxObjects;
    [SerializeField] private Vector2 areaMin;
    [SerializeField] private Vector2 areaMax;

    private readonly List<GameObject> spawned = new List<GameObject>();

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnInterval, spawnInterval);
    }

    private void Spawn()
    {
        spawned.RemoveAll(o => o == null);
        if (spawned.Count >= maxObjects) return;

        Vector2 position = new Vector2(
            Random.Range(areaMin.x, areaMax.x),
            Random.Range(areaMin.y, areaMax.y)
        );

        spawned.Add(Instantiate(prefab, position, Quaternion.identity));
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 center = (areaMin + areaMax) / 2f;
        Vector3 size = areaMax - areaMin;
        Gizmos.DrawWireCube(center, size);
    }
}