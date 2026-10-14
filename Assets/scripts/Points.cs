using UnityEditor.TerrainTools;
using UnityEngine;
using TMPro;
using Unity.Collections.Tests.CoreCLR.TestJobs;

public class Points : MonoBehaviour
{
    [SerializeField] private TMP_Text pointsText;
    private int points = 0;

    private void Start()
    {
        pointsText.text = "Points: " + points;
    }
   
    public void increasepoints(int amount)
    {
        points += amount;
        pointsText.text = "Points: " + points;
    }
}
