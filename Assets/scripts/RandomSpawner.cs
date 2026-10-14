using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Points points;
    [SerializeField] private float spawnInterval;
    [SerializeField] private int maxObjects;
    [SerializeField] private Vector2 areaMin;
    [SerializeField] private Vector2 areaMax;

    private int currentCount;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnInterval, spawnInterval);
    }

    private void Spawn()
    {
        if (currentCount >= maxObjects) return;

        Vector2 position = new Vector2(
            Random.Range(areaMin.x, areaMax.x),
            Random.Range(areaMin.y, areaMax.y)
        );

        GameObject obj = Instantiate(prefab, position, Quaternion.identity);
        obj.GetComponent<Fruit>().Init(points);
        currentCount++;

        var tracker = obj.AddComponent<SpawnTracker>();
        tracker.onDestroyed = () => currentCount--;
    }
}

public class SpawnTracker : MonoBehaviour
{
    public System.Action onDestroyed;

    private void OnDestroy()
    {
        onDestroyed?.Invoke();
    }
}