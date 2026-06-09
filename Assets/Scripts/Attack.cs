using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private float attackDamage = 1f;
    [SerializeField]
    private float attackRange = 5f;


    // Update is called once per frame
    void Update()
    {
        // By pressing the Left Mouse Button
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            // Checking if a GameObject is nearby
            if (Physics2D.OverlapCircle(this.transform.position, attackRange))
            {
                Health enemy = GetComponent<Health>();
                enemy.TakeDamage(attackDamage);
                Debug.Log($"Enemy attack with {attackDamage} Damage");
            }
            else { Debug.Log("No Enemy found"); }
        }
    }
}
