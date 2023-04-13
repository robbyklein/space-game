using UnityEngine;

public class WorldMovement : MonoBehaviour {
    Rigidbody2D rb;
    BoxCollider2D bc;

    Vector2 Extents;
    float ScreenWidth;
    float ScreenHeight;
    int xDirection, yDirection;
    float xOffset, yOffset;
    Vector2 position, truePosition;
    Camera mainCamera;

    [SerializeField] int speed = 10;
    [SerializeField] int turnSpeed = 100;
    [SerializeField] private float accelerationSpeed = 5f;
    [SerializeField] private float decelerationSpeed = 10f;
    [SerializeField] private float accelerator = 1.2f;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();

        mainCamera = Camera.main;
        Extents = bc.bounds.extents;
        ScreenWidth = Camera.main.scaledPixelWidth;
        ScreenHeight = Camera.main.scaledPixelHeight;
    }

    void Update() {
        LoopPosition();
    }

    public void LoopPosition() {
        xDirection = rb.velocity.x > 0 ? -1 : 1;
        yDirection = rb.velocity.y > 0 ? -1 : 1;
        xOffset = Extents.x * xDirection;
        yOffset = Extents.y * yDirection;

        position = new Vector2(rb.transform.position.x + xOffset, rb.transform.position.y + yOffset);
        truePosition = mainCamera.WorldToScreenPoint(position);

        // Loop X
        if (xDirection > 0 && truePosition.x < 0) {
            rb.transform.position = new Vector2(rb.transform.position.x * -1, rb.transform.position.y * -1);
        } else if (xDirection < 0 && truePosition.x > ScreenWidth) {
            rb.transform.position = new Vector2(rb.transform.position.x * -1, rb.transform.position.y * -1);
        }

        // Loop y
        if (yDirection > 0 && truePosition.y < 0) {
            rb.transform.position = new Vector2(rb.transform.position.x * -1, rb.transform.position.y * -1);
        } else if (yDirection < 0 && truePosition.y > ScreenHeight) {
            rb.transform.position = new Vector2(rb.transform.position.x * -1, rb.transform.position.y * -1);
        }
    }

    public void Move(Vector2 moveInput) {
        float horizontalForce = CalculateForce(moveInput.x);
        float verticalForce = CalculateForce(moveInput.y);
        rb.AddForce(new Vector2(horizontalForce, verticalForce) * Time.deltaTime);
    }

    public void Turn(Vector2 turnInput) {
        float turnAmount = turnInput.x * turnSpeed;
        transform.Rotate(new Vector3(0, 0, turnAmount) * Time.deltaTime);
    }

    float CalculateForce(float inputAmount) {
        float targetSpeed = inputAmount * speed;
        float speedDifference = targetSpeed - inputAmount;
        float changeRate = Mathf.Abs(targetSpeed) > 0.1f ? accelerationSpeed : decelerationSpeed;
        return Mathf.Pow(Mathf.Abs(speedDifference) * changeRate, accelerator) * Mathf.Sign(speedDifference);
    }
}
