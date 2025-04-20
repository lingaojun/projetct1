using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; // 跟随目标
    public float followSpeed = 2f; // 跟随速度
    public float minDistance = 2f; // 最小距离
    public float maxDistance = 4f; // 最大距离
    public float changeDirectionInterval = 2f; // 改变方向的时间间隔
    
    private Vector2 randomOffset;
    private float nextDirectionChange;

    void Start()
    {
        UpdateRandomOffset();
    }

    void Update()
    {
        if (target == null) return;

        // 定期更新随机偏移
        if (Time.time >= nextDirectionChange)
        {
            UpdateRandomOffset();
            nextDirectionChange = Time.time + changeDirectionInterval;
        }

        // 计算目标位置（包含随机偏移）
        Vector2 targetPos = (Vector2)target.position + randomOffset;
        
        // 平滑移动
        Vector2 currentPos = transform.position;
        float distance = Vector2.Distance(currentPos, targetPos);

        // 根据距离调整速度
        float speedMultiplier = Mathf.Clamp(distance / maxDistance, 0.5f, 1.5f);
        
        // 移动
        transform.position = Vector2.Lerp(currentPos, targetPos, followSpeed * speedMultiplier * Time.deltaTime);
    }

    void UpdateRandomOffset()
    {
        // 生成一个随机方向和距离
        float randomAngle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        float randomDistance = Random.Range(minDistance, maxDistance);
        randomOffset = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle)) * randomDistance;
    }
} 