using UnityEngine;

public class MovingBackground : MonoBehaviour {
    BoxCollider2D collider;

    [SerializeField] float speed = 0.005f;
    float HalfHeight;
    float InitialYPosition;
    float EndPosition;

    // Start is called before the first frame update
    void Start() {
        collider = GetComponent<BoxCollider2D>();
        HalfHeight = collider.bounds.size.y / 2;
        InitialYPosition = transform.position.y;
        EndPosition = InitialYPosition - HalfHeight;
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (transform.position.y > EndPosition) {
            transform.position = new Vector3(transform.position.x, transform.position.y - (speed * Time.deltaTime), transform.position.z);
        } else {
            transform.position = new Vector3(transform.position.x, InitialYPosition, transform.position.z);
        }
    }
}
