using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    public float offset = 10f;

    private Vector3 velocity = Vector3.zero;

    [SerializeField]
    private Rect bounds = new Rect(-10f, -10f, 20f, 20f);

    private void LateUpdate()
    {
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, -offset));

        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 resultPosition = (targetPosition * 2 + mousePos) / 3;


        transform.position = Vector3.SmoothDamp(transform.position, resultPosition, ref velocity, smoothTime);

        float cameraSize = Camera.main.orthographicSize;
        float cameraWidth = cameraSize * Camera.main.aspect;
        float cameraHeight = cameraSize;

        float x = Mathf.Clamp(transform.position.x, bounds.xMin + cameraWidth, bounds.xMax - cameraWidth);
        float y = Mathf.Clamp(transform.position.y, bounds.yMin + cameraHeight, bounds.yMax - cameraHeight);
        transform.position = new Vector3(x, y, transform.position.z);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(bounds.center, bounds.size);
    }
}