using UnityEngine;

public class TileLooper : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 2f;
    private float tileWidth;

    private void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        tileWidth = sr.bounds.size.x;
    }

    private void Update()
    {
        transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);

        // Jika keluar dari kamera kiri, geser ke kanan
        if (transform.position.x <= -tileWidth)
        {
            Vector3 newPos = transform.position;
            newPos.x += tileWidth * 2f; // Asumsi pakai 2 tile
            transform.position = newPos;
        }
    }
}
