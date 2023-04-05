using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] Projectile projectile;
    [SerializeField] InputManager inputManager;
    WorldMovement worldMovement;

    void Start() {
        worldMovement = GetComponent<WorldMovement>();
    }

    void Update() {
        worldMovement.Move(inputManager.MovementInput);
        worldMovement.Turn(inputManager.TurnInput);
    }

}

