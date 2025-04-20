using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    public Transform target; // 跟随的目标(Player) 
    [SerializeField]
    public float smoothSpeed = 0.125f; // 平滑跟随的速度
    [SerializeField]
    public Vector3 offset = new Vector3(0, 0, -10); // 相机和目标之间的偏移

    void LateUpdate()
    {
        if (target == null)
            return;

        // 计算目标位置
        Vector3 desiredPosition = target.position + offset;
        
        // 平滑移动到目标位置
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
} 