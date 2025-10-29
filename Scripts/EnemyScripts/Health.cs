using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Handles the enemies health
public class Health : MonoBehaviour
{
   [Header("Events")]
   public static UnityEvent onEnemyDestroy = new UnityEvent(); // Event for when the enemy is destroyed
   
  
   private int currentHealth;
   private bool isDestroyed = false;

   private Enemy enemy;
   
   // when an enemy gets destroyed call the enemy destroyed funciton
   private void Awake()
   {
      enemy = GetComponent<Enemy>();
      currentHealth = enemy.Data.MaxHealth;
      //onEnemyDestroy.AddListener(Die); // TODO FIX
   }
   
   // Called when the bulled hits the enemy
   public void TakeDamage(int dmg)
   {
      currentHealth -= dmg;

      if (currentHealth <= 0 && !isDestroyed)
      {
         Die();
      }
   }
   
   // Handles enemy dealth by reaching the end of the map
   public void KillWithoutReward()
   {
      if (!isDestroyed)
      {
         isDestroyed = true;
         // Still count toward wave cleanup
         onEnemyDestroy.Invoke();
         Destroy(gameObject);
      }
   }

   // Handle enemy death when dieing to a tower
   private void Die()
   {
      isDestroyed = true;
      // Notify event systems
      onEnemyDestroy.Invoke();
      LevelManager.main.IncreaseCurrency(enemy.Data.CurrencyReward);
      // Destroy this enemy
      Destroy(gameObject);
   }
   
}
