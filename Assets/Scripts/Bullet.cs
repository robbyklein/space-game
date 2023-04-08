using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] LayerMask boundryMask;

    float speed = 10f;
    Rigidbody2D rb;
    Animator animator;
    BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        rb.velocity = transform.up * speed;
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (!boundryMask.IsInMask(collision.gameObject.layer)) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        rb.velocity = Vector2.zero;
        boxCollider.size = Vector2.zero;
        animator.SetTrigger("Explode");
    }

    void DestroyBullet() {
        Destroy(gameObject);
    }


}
