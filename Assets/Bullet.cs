using UnityEngine;

public class Bullet : MonoBehaviour {
    float speed = 10f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag != "Boundries") {
            Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Boundries") {
            Destroy(gameObject);
        }
    }
}
