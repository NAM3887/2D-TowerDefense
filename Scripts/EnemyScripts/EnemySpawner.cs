using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")] 
    // array of enemies prefabs, used when spawning enemies
    [SerializeField] private GameObject[] enemyPrefabs;
    
    [Header("Attributes")] 
    [SerializeField] private int baseEnemies = 8; // stating amount of enemies that spawn on the first wave
    [SerializeField] private float enemiesPerSecond = .5f; // the amount of enemies that will spawn per seccond
    [SerializeField] private float enemiesPerSecondCap = 10f; // Caped amount of enemies per second
    [SerializeField] private float timeBetweenWaves = 5f;  // the time between the last enemy killed and the start of the next wave
    [SerializeField] private float difficultyScalingFactor = 0.75f; // used for scaling up the amount of enemies and enemies per second that spawn
    
    
    //private int currentWave = 1;
    private float timeSinceLastSpawn; // used for spawning a certain amount of enemies per second
    private int enemiesAlive; // this amount gets added and subtracted from when enemies spawn and die
    private int enemiesLeftToSpawn; // how many enemies are left to spawn in this round
    private float spawnRate; // enemies per second
    private bool isSpawning = false; // are enemies currently spawning

    void Start()
    {
        StartCoroutine(StartWave()); // start the first wave
    }
    
    // Update is called once per frame
    // Handle Spawning enemies, and spawn timers
    private void Update()
    {
        // if enemies are not supposed to be spawning return
        if (!isSpawning) return;
        
        // start the time since last spawn counter   
        timeSinceLastSpawn += Time.deltaTime;
        
        // check if we can spawn an enemy
        if (timeSinceLastSpawn >= (1f / spawnRate) &&  enemiesLeftToSpawn > 0)
        {
            // Spawn the enemy, Update spawning variables
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f; // reset time since last spawn timer
        }
        // End the Wave when there are no more enemies alive and no more enemies left to spawn
        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }
    
    // Used to spawn enemies it randomly selects an enemy to spawn then instanitiates it
    private void SpawnEnemy()
    {
        // spawn an enemy randomly from the enemy prefab list
        int index = Random.Range(0, enemyPrefabs.Length);
        GameObject prefabToSpawn = enemyPrefabs[index];
        Instantiate(prefabToSpawn, LevelManager.main.StartPoint.position, Quaternion.identity);
    }
    
    // Starts the wave, and start timeBetweenWaves timer
    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves); // only start this between waves
        isSpawning = true;
        int wave = LevelManager.main.GetCurrentWave(); // Get the wave 
        // Difficulty scaling for new wave
        enemiesLeftToSpawn = GetEnemiesPerWave(wave);
        spawnRate = GetEnemiesPerSecond(wave);
    }
    
    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        int newWave = LevelManager.main.GetCurrentWave() + 1;
        LevelManager.main.SetWave(newWave); // Wave gets set in level manager
        StartCoroutine(StartWave());
    }
    
    // Scales the amount of enemies per wave with the difficuly scaling factior
    private int GetEnemiesPerWave(int wave)
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(wave, difficultyScalingFactor));
    }
    
    // Scales the enemies per second with the difficuly scaling factior
    private float GetEnemiesPerSecond(int wave)
    {
        return Mathf.Clamp(enemiesPerSecond * Mathf.Pow(wave, difficultyScalingFactor), 0f,enemiesPerSecondCap);
    }
    
    // Called when an enemy gets destroyed
    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }
    
    private void OnEnable()
    {
        EnemyHealth.onEnemyDestroy.AddListener(EnemyDestroyed);
    }
    private void OnDisable()
    {
        EnemyHealth.onEnemyDestroy.RemoveListener(EnemyDestroyed);
    }

    
}
