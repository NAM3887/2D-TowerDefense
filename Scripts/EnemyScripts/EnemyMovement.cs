using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Handles enemy movement and Navigates the points in the path
public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb; // reference to the rigid body of the enemy
    
    private Enemy enemy; // Reference to enemy
    private float moveSpeed;
    private float baseSpeed;
    
    // Path variables
    private Transform target; // this is the point in the path that the enemy will be moving towards
    private int pathIndex = 0; 
    
    // Initialize vairables, moveSpeed to base move speed and Set the target to the start of the path
    void Start()
    {
        enemy = GetComponent<Enemy>();
        baseSpeed = enemy.Data.Speed;
        moveSpeed = baseSpeed;
        
        target = LevelManager.main.Path[pathIndex];
    }
    
    /* Used for navigating the path, it checks if the enemy has reached the target.
        If the enemy reached the target, check if it is at the end of the path,if it is punish the player and destroy the enemy. 
        If the enemy is not the end of the path, update the target to the next point in the path. */
    void Update()
    {
        // check if the enemy reached the target
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            // increment to the next point in the path 
            pathIndex++;
            
            // Handle enemy reaching the end of the path, destroy enemy and punish player
            if (pathIndex == LevelManager.main.Path.Length)
            {
                EnemyReachedEnd();
                return;
            }
            // Update the target to the next point
            target = LevelManager.main.Path[pathIndex];
        }
    } 
    
    /*                                                                             **
    In Unity, FixedUpdate is a function that is called at a fixed time interval,   **
      independent of the frame rate. It's primarily used for physics calculations  **
       and any other logic that needs to be executed at a consistent rate,         **
        ensuring that physics simulations are stable and predictable               **
                                                           -google search ai       **/
    /* Fixed Update is used to move the enemy in the direction of the next
     then it sets the velocity of the rigid body to the normalized direction vector * the magnitude of the moveSpeed */
    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized; // target null ref here

        rb.linearVelocity = direction * moveSpeed;
    }
    
    // Updates the speed of the enemy to the new speed, this is used for the slow tower
    // TODO could make it get slowed at a rate so its not just intantly updated to a new speed it could gradually change over time, that could be a new function
    public void UpdateSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }
    
    // Resets the moveSpeed of the enemy back to the base movement speed,
    // this is used when the enemy exits the range of the slow tower
    public void ResetSpeed()
    {
        moveSpeed = baseSpeed;
    }
    
    // Handles when the enemy reaches the end of the path
    private void EnemyReachedEnd()
    {
        LevelManager.main.LoseLives(enemy.Data.Damage);
        GetComponent<EnemyHealth>().KillWithoutReward();
    }

}
