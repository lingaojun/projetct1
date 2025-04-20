using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public float offsetX = 1f; // 武器在角色右侧的偏移距离
    public Transform player; // 玩家引用

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        // 确保初始状态下武器不可见
        spriteRenderer.enabled = false;
    }

    void Update()
    {
        // 更新武器位置，跟随玩家
        if (player != null)
        {
            // 获取玩家朝向
            bool isFacingLeft = player.GetComponent<SpriteRenderer>().flipX;
            
            // 根据玩家朝向调整武器位置和方向
            Vector3 weaponPosition = player.position;
            weaponPosition.x += isFacingLeft ? -offsetX : offsetX;
            transform.position = weaponPosition;
            
            // 调整武器朝向
            spriteRenderer.flipX = isFacingLeft;
        }

        // 检测攻击输入
        if (Input.GetKey(KeyCode.J))
        {
            Attack();
        }
        else if (Input.GetKeyUp(KeyCode.J))
        {
            StopAttack();
        }
    }

    void Attack()
    {
        // 显示武器
        spriteRenderer.enabled = true;
        
        // 触发攻击动画
        animator.SetTrigger("Attack");
    }

    void StopAttack()
    {
        // 重置攻击触发器
        animator.ResetTrigger("Attack");
        
        // 重置到默认状态
        animator.Play("Idle");
        
        // 隐藏武器
        spriteRenderer.enabled = false;
    }

    // 动画事件调用，在动画结束时隐藏武器
    public void OnAttackFinished()
    {
        spriteRenderer.enabled = false;
    }
} 