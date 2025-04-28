using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
//     public float flapForce = 5f;
//     private Rigidbody2D rb;
//     private Animator anim;
    
//     private void Awake()
//     {
//         rb = GetComponent<Rigidbody2D>();
//         anim = GetComponent<Animator>();
//     }

//     public void OnFlap(InputAction.CallbackContext context)
//     {
//         if (context.performed) // Jika tombol ditekan
//         {
//             rb.linearVelocity = Vector2.up * flapForce;
//             anim.SetTrigger("Flap");
//         }
//     }

//     private void Update()
//     {
//         // Animasi transisi ke Fall jika kecepatan negatif
//         if (rb.linearVelocity.y < 0)
//         {
//             anim.SetBool("Falling", true);
//         }
//         else
//         {
//             anim.SetBool("Falling", false);
//         }
//     }
// }
public float flapForce = 5f;
    public float maxYPosition = 4.5f;
    public float minYPosition = -4.5f;

    private Rigidbody2D rb;
    private Animator animator;
    private bool hasStarted = false;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.gravityScale = 0;
    }
    public void OnFlap(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            if(!hasStarted)
            {
                rb.gravityScale = 3;
                hasStarted = true;
            }

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, flapForce);
            animator.SetTrigger("Flap");
        }
    }

    void Update()
    {
        if(rb.linearVelocity.y < 0)
        {
            animator.SetBool("Falling", true);
        }
        else
        {
            animator.SetBool("Falling", false);
        }

         // Batasi posisi Y agar tidak keluar dari batas atas

        if(transform.position.y > maxYPosition)
        {
            transform.position = new Vector3(transform.position.x, maxYPosition, transform.position.y);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        }
        else if (transform.position.y < minYPosition) 
        {
            Destroy(gameObject);
        }
    }
}
