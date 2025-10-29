using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Configuration")]
    [SerializeField] private EnemyData enemyData;
    public EnemyData Data => enemyData; // Expose read-only property

    private void Awake()
    {
        // validate that enemyData is assigned
        if (enemyData == null)
        {
            Debug.LogError($"EnemyData is missing on {gameObject.name}");
        }
    }
}