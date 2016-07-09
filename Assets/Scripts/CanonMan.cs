using UnityEngine;
using UnityEngine.SceneManagement;
public class CanonMan : MonoBehaviour
{
    Fire fireButton;
    Rigidbody2D rigidbody;
    SpriteRenderer renderer;
    bool isGround, teleport;
    // Use this for initialization
    void Start()
    {
        fireButton = GameObject.Find("FireButton").GetComponent<Fire>();
        rigidbody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        isGround = false;
        teleport = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fireButton.GetComponent<Fire>().canShot)
        {
            rigidbody.gravityScale = 1;
            rigidbody.AddForce(transform.parent.up * fireButton.force, ForceMode2D.Impulse);
            fireButton.canShot = false;
            transform.SetParent(null);
        }
        if (!transform.parent)
        {
            if (rigidbody.velocity != Vector2.zero && !isGround)
                transform.up = rigidbody.velocity.normalized;
            else
                transform.up = Vector2.right;
            if (rigidbody.velocity.x > 0)
                renderer.flipX = false;
            else
                renderer.flipX = true;
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        //derrota
        if (c.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
        //vitoria
        else if (c.gameObject.CompareTag("Target"))
        {
            Debug.Log("gg");
        }

    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("Portal") && !teleport)
        {
            rigidbody.position = c.gameObject.GetComponent<Portal>().getPairPosition();
            teleport = true;
        }
        else if (c.gameObject.CompareTag("Spring"))
        {
            rigidbody.AddForce(c.gameObject.transform.up * c.gameObject.GetComponent<Mola>().mult * rigidbody.velocity.magnitude, ForceMode2D.Impulse);
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("Portal") && !teleport)
        {
            teleport = false;
        }
    }
}
