using UnityEngine;

public class ScreenBoundries : MonoBehaviour {
    Vector2 ScreenBounds;
    float ObjectWidth;
    float ObjectHeight;

    // Start is called before the first frame update
    void Start() {
        ScreenBounds = Camera.main.ScreenToWorldPoint(
            new Vector3(
                Screen.width,
                Screen.height,
                Camera.main.transform.position.z
            )
        );

        ObjectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        ObjectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;

    }

    // Update is called once per frame
    void LateUpdate() {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, (ScreenBounds.x * -1) + ObjectWidth, ScreenBounds.x - ObjectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, (ScreenBounds.y * -1) + ObjectHeight, ScreenBounds.y - ObjectHeight);
        transform.position = viewPos;
    }
}
