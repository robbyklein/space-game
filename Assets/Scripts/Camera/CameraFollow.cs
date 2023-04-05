using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [SerializeField] Transform followTransform;

    // Update is called once per frame
    void Update() {
        transform.position = new Vector3(
            followTransform.position.x,
            followTransform.position.y,
            transform.position.z
        );
    }
}
