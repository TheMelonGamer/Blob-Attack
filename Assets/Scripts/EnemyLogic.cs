using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 4f;
    [SerializeField]
    private float attackDamage = 1f;
    [SerializeField]
    private float attackSpeed = 2f;
    [SerializeField]
    private float attackRange = 1f;
    [SerializeField]
    private Transform player;

    private EnemyState currentState;
    private float attackTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = EnemyState.Idle;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // attackTimer run
        attackTimer -= Time.deltaTime;

        switch (currentState)
        {
            case EnemyState.Idle:
                Idle();
                break;

            case EnemyState.Chase:
                Chase();
                break;

            case EnemyState.Attack:
                Attack();
                break;
        }
    }

    // --- Private Methods
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            currentState = EnemyState.Chase;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            currentState = EnemyState.Idle;
        }
    }

    private void Idle()
    {
        // Play Idle Animation
    }

    // Followed the Player
    private void Chase()
    {
        // Calculate the Distance between Player and Enemy
        float distance = Vector2.Distance(transform.position, player.position);

        // If the Player is within range, the Enemy enters attack mode
        if (distance <= attackRange)
        {
            currentState = EnemyState.Attack;
            return;
        }

        // Follows Player
        transform.position = Vector2.MoveTowards(
            transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    private void Attack()
    {
        // Calculate the distance between Player and Enemy
        float distance = Vector2.Distance(transform.position, player.position);

        // If the Player is not in range, the Enemy enters chase mode
        if (distance > attackRange)
        {
            currentState = EnemyState.Chase;
            return;
        }

        // Attacks the Player with a amount of time
        if (attackTimer <= 0)
        {
            // Damages the Player
            Health playerHealth = player.GetComponent<Health>();
            playerHealth.TakeDamage(attackDamage);

            attackTimer = attackSpeed;
        }
    }
}
