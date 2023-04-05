using UnityEngine;

public class Weapon : MonoBehaviour {
    [SerializeField] InputManager inputManager;
    [SerializeField] Transform FirePoint;
    [SerializeField] GameObject ProjectilePrefab;

    void OnEnable() {
        inputManager.OnPlayingFire += HandleFire;
    }

    void OnDisable() {
        inputManager.OnPlayingFire -= HandleFire;
    }

    void HandleFire() {
        Instantiate(ProjectilePrefab, FirePoint.position, FirePoint.rotation);
    }
}
