using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] private int pointsValue;
    private Points points;

    public void Init(Points pointsRef)
    {
        points = pointsRef;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        points.increasepoints(pointsValue);
        Destroy(gameObject);
    }
}