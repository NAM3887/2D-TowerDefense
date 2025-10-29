using UnityEngine;
// this is a scriptable object script, its purpose is to hold Data that goes along with each enemy 
[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Enemies/Enemy Data")] // This will show when making a new asset in the right click menu
public class EnemyData : ScriptableObject
{
    [SerializeField] private string enemyName = "Enemy";
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private int damage = 1;
    [SerializeField] private int currencyReward = 5;
    [SerializeField] private float speed = 1f;

    // public read only properties
    public string EnemyName => enemyName;
    public int MaxHealth => maxHealth;
    public int Damage => damage;
    public int CurrencyReward => currencyReward;
    public float Speed => speed;
}
