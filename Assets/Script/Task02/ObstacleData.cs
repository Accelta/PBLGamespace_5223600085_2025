using UnityEngine;

[CreateAssetMenu(fileName = "NewObstacleData", menuName = "Game/Obstacle Data")]
public class ObstacleData : ScriptableObject
{
    public float moveSpeed = 2.5f;
    public float spawnInterval = 1.5f;
    public float minGapY = -2.0f;
    public float maxGapY = 2.0f;
}
