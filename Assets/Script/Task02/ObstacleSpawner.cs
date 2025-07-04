using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;  // Prefab containing top and bottom pipes
    public ObstacleData obstacleData;  // Reference to move speed and spawn settings
    public Transform spawnPoint;       // Spawn position (right side of the screen)
    public float gapSize = 2.5f;       // Space between pipes

    private float timer;

    void Update()
    {
        if (!PlayerController.HasGameStarted)
        {
            return;
        }
        timer += Time.deltaTime;
        if (timer >= obstacleData.spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        float randomY = Random.Range(obstacleData.minGapY, obstacleData.maxGapY);
        Vector3 spawnPos = new Vector3(spawnPoint.position.x, randomY, 0);

        GameObject newObstacle = Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);

        // Ensure the spawned obstacle is active
        newObstacle.SetActive(true);

        // Adjust top and bottom pipe positions relative to the gap
        Transform topPipe = newObstacle.transform.Find("TopPipe");
        Transform bottomPipe = newObstacle.transform.Find("BottomPipe");

        if (topPipe && bottomPipe)
        {
            topPipe.position = new Vector3(spawnPos.x, spawnPos.y + (gapSize / 2), 0);
            bottomPipe.position = new Vector3(spawnPos.x, spawnPos.y - (gapSize / 2), 0);
        }
    }
}
