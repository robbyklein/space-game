using UnityEngine;

public class Weapon : MonoBehaviour {
    [SerializeField] InputManager inputManager;
    [SerializeField] Transform FirePoint;
    [SerializeField] GameObject ProjectilePrefab;
    [SerializeField] GameObjectPool pool = new GameObjectPool();

    [SerializeField] float fireRate = 0.1f;
    bool Firing = false;
    private float lastFire = 0.0f;

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
        var firedBullet = pool.Get();
        firedBullet.transform.position = FirePoint.position;
        firedBullet.transform.rotation = FirePoint.rotation;
        firedBullet.GetComponent<Bullet>().Fire();
    }
}
