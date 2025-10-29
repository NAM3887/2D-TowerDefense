using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SlowTurret : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private LayerMask EnemyMask;

    [Header("Attributes")] 
    [SerializeField] private float targetingRange = 2.5f;
    [SerializeField] private float attacksPerSecond = .25f;
    [SerializeField] private float slowFactor = .5f;
    [SerializeField] private float freezeTime = 1f;
    
    private float timeUntilFire;

    private void Update()
    {
        timeUntilFire += Time.deltaTime;
        if (timeUntilFire >= 1f / attacksPerSecond)
        {
            FreezeEnemies();
            timeUntilFire = 0f;
        }
    }

    private void FreezeEnemies()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(
            transform.position,
            targetingRange,
            Vector2.zero,
            0f,
            EnemyMask
        );

        foreach (RaycastHit2D hit in hits)
        {
            EnemyMovement enemyMovement = hit.transform.GetComponent<EnemyMovement>();
            if (enemyMovement != null)
            {
                enemyMovement.UpdateSpeed(slowFactor);
                StartCoroutine(ResetEnemySpeed(enemyMovement));
            }
        }
    }

    private IEnumerator ResetEnemySpeed(EnemyMovement eM)
    {
        yield return new WaitForSeconds(freezeTime);
        eM.ResetSpeed();
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.blue;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }
#endif
}