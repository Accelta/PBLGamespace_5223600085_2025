using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float flapForce = 5f;
    private Rigidbody2D rb;
    private Animator anim;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void OnFlap(InputAction.CallbackContext context)
    {
        if (context.performed) // Jika tombol ditekan
        {
            rb.linearVelocity = Vector2.up * flapForce;
            anim.SetTrigger("Flap");
        }
    }

    private void Update()
    {
        // Animasi transisi ke Fall jika kecepatan negatif
        if (rb.linearVelocity.y < 0)
        {
            anim.SetBool("Falling", true);
        }
        else
        {
            anim.SetBool("Falling", false);
        }
    }
}
