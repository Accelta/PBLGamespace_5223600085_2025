using UnityEngine;

public class TileLooper : MonoBehaviour
{
[SerializeField] private float speed = 2f;
[SerializeField] private float width;
private SpriteRenderer spriterenderer;
private Vector2 startsize;

    private void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
        startsize = new Vector2(spriterenderer.size.x,spriterenderer.size.y);
    }
    private void Update()
    {
        spriterenderer.size = new Vector2(spriterenderer.size.x +speed *Time.deltaTime, spriterenderer.size.y);
        if (spriterenderer.size.x >= width)
        {
            spriterenderer.size = startsize;
        }
    }
}
