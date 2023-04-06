using UnityEngine;

public class Weapon : MonoBehaviour {
    [SerializeField] InputManager inputManager;
    [SerializeField] Transform FirePoint;
    [SerializeField] GameObject ProjectilePrefab;

    bool Firing = false;
    private float lastFire = 0.0f;
    public float fireRate = 0.1f;

    private void Update() {
        if (Firing && Time.time > lastFire + fireRate) {
            lastFire = Time.time;
            Fire();
        }
    }

    void OnEnable() {
        inputManager.OnPlayingFire += HandleFire;
        inputManager.OnPlayingFireCanceled += HandleFireCancel;
    }

    void OnDisable() {
        inputManager.OnPlayingFire -= HandleFire;
        inputManager.OnPlayingFireCanceled -= HandleFireCancel;
    }

    void HandleFire() {
        Firing = true;
    }

    void HandleFireCancel() {
        Firing = false;
    }

    void Fire() {
        Instantiate(ProjectilePrefab, FirePoint.position, FirePoint.rotation);
    }
}
