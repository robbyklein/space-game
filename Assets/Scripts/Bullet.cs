using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] LayerMask boundryMask;

    float speed = 10f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
    }



    void OnTriggerExit2D(Collider2D collision) {
        if (!boundryMask.IsInMask(collision.gameObject.layer)) {
            Destroy(gameObject);
        }
    }
}
