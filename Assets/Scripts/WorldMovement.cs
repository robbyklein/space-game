using UnityEngine;

public class WorldMovement : MonoBehaviour {
    Rigidbody2D rb;

    [SerializeField] int speed = 10;
    [SerializeField] int turnSpeed = 100;
    [SerializeField] private float accelerationSpeed = 5f;
    [SerializeField] private float decelerationSpeed = 10f;
    [SerializeField] private float accelerator = 1.2f;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
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
