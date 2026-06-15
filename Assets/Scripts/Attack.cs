using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private float attackDamage = 1f;
    [SerializeField]
    private float attackRange = 2f;
    [SerializeField]
    private LayerMask enemyLayer;


    // Update is called once per frame
    void Update()
    {
        // By pressing the Left Mouse Button
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            // Checking if a GameObject is nearby
            Collider2D[] enemies = Physics2D.OverlapCircleAll(
                transform.position, attackRange, enemyLayer);

            // Attack any Enemy within range
            foreach (Collider2D enemyCollider in enemies)
            {
                if (enemyCollider.TryGetComponent<Health>(out Health enemy))
                { 
                    enemy.TakeDamage(attackDamage);
                    Debug.Log($"{enemy.name} attack with {attackDamage} Damage");
                }
            }

            if (enemies.Length == 0)
            { 
                Debug.Log("No Enemy found"); 
            }
        }
    }
}
