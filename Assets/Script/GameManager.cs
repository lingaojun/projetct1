using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab; // 玩家预制体
    public Transform mainPlayer; // 主角引用
    public float spawnRadius = 5f; // 生成范围半径

    void Update()
    {
        // 检测F1按键
        if (Input.GetKeyDown(KeyCode.F1))
        {
            CreateNewPlayer();
        }
    }

    void CreateNewPlayer()
    {
        if (mainPlayer == null) return;

        // 在主角周围随机位置生成
        Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = mainPlayer.position + new Vector3(randomPosition.x, randomPosition.y, 0);
        
        // 实例化玩家预制体
        GameObject newPlayer = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
        
        // 添加并设置跟随行为
        FollowPlayer followComponent = newPlayer.AddComponent<FollowPlayer>();
        followComponent.target = mainPlayer;
    }
} 