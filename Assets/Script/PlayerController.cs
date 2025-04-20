using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public float moveSpeed = 5f;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 获取水平和垂直输入(-1到1)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // 创建移动向量并标准化
        Vector2 movement = new Vector2(moveX, moveY);
        if (movement.magnitude > 0)
        {
            movement.Normalize();
        }

        // 移动角色
        transform.position += (Vector3)movement * moveSpeed * Time.deltaTime;

        // 检查是否在移动
        bool isMoving = movement.magnitude > 0.1f;
        
        // 设置动画状态
        animator.SetBool("isWalking", isMoving);
        animator.SetBool("isIdle", !isMoving);

        // 控制角色朝向
        if (moveX != 0)
        {
            spriteRenderer.flipX = (moveX < 0);
        }
    }
}