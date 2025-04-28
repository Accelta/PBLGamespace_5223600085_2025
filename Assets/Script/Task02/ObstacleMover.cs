using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public ObstacleData obstacleData;

    void Update()
    {
        transform.position += Vector3.left * obstacleData.moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Despawner"))
        {
            Destroy(gameObject);
        }
    }
}
