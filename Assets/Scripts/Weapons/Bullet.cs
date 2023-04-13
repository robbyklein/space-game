using System;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public event Action<Bullet> BulletFreed;

    [SerializeField] LayerMask boundryMask;
    [SerializeField] LayerMask playerMask;
    [SerializeField] float speed = 10f;

    Rigidbody2D rb;
    Animator animator;
    BoxCollider2D boxCollider;
    public GameObjectPool Pool;

    void Awake() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
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
        BulletFreed?.Invoke(this);
    }

    public void Fire() {
        rb.velocity = transform.up * speed;
    }
}
