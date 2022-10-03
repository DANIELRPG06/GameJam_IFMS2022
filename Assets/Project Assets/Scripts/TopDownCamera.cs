using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    public float offset = 10f;

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, -offset));

        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 resultPosition = (targetPosition*2 + mousePos) / 3;


        transform.position = Vector3.SmoothDamp(transform.position, resultPosition, ref velocity, smoothTime);
    }
}