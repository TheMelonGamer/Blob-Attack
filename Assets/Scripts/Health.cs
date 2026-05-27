using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float health = 10f;
    [SerializeField]
    private float maxHealth = 10f;

    private bool isAlive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // --- Public Methods
    // Damages the Player
    public void TakeDamage(float damage)
    {
        if (isAlive)
        {
            if (health < damage)
            {
                health -= damage;
            } else
            {
                Death();
            }
        }
    }

    // Heales the Player
    public void Heal(float amount)
    {
        if (isAlive)
        {
            if (health + amount < maxHealth)
            {
                health += amount;
            }
            else
            {
                health = maxHealth;
            }
        }
    }

    // Kills the Player
    public void KillPlayer()
    {
        if (isAlive)
        {
            health = 0;
            Death();
        }
    }

    // --- Private Methods

    // If the Player is dead
    private void Death()
    {
        isAlive = false;
        // Destroy Player
        // Play Animation
    }
}
