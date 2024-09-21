using UnityEngine;

public class CameraFollow : BaseMono
{
    [SerializeField] protected Transform target;  // Đối tượng mà camera sẽ theo dõi (nhân vật)
    public float smoothSpeed = 0.125f;  // Tốc độ làm mượt camera
    public Vector3 offset;  // Độ lệch của camera so với vị trí nhân vật

    public Vector2 minBounds; // Giới hạn tối thiểu của camera
    public Vector2 maxBounds;  // Giới hạn tối đa của camera

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Giới hạn vị trí của camera trong phạm vi bản đồ
            smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, minBounds.x, maxBounds.x);
            smoothedPosition.y = Mathf.Clamp(smoothedPosition.y, minBounds.y, maxBounds.y);

            transform.parent.position = smoothedPosition;
        }
    }
}
