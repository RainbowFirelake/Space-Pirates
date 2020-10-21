using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float currentHealth = 100f;
    [SerializeField] private float maxHealth = 100f;

    private bool isDead;
    private bool isPlayer;

    public delegate void PlayerKill();
    public static event PlayerKill playerKill;

    public delegate void PlayerUpdateHP(float value, float maxValue);
    public static event PlayerUpdateHP playerUpdateHP;

    private void Start() {
        isPlayer = GetComponent<PlayerController>();
        playerUpdateHP(currentHealth, maxHealth);
    }

    public void TakeDamage(float damage, bool isPlayerHit)
    {
        currentHealth -= Mathf.Clamp(damage, 0f, 100f);
        if (isPlayer)
        {
            playerUpdateHP(currentHealth, maxHealth);
        }  
        CheckDeath(isPlayerHit);
    }

    public void AddHealth(float health)
    {
        currentHealth += Mathf.Clamp(health, 0, maxHealth);
        if (isPlayer)
        {
            playerUpdateHP(currentHealth, maxHealth);
        }
    }

    private void CheckDeath(bool isPlayerHit)
    {
        if (currentHealth <= 0.1f)
        {
            if (isPlayerHit)
            {
                playerKill();
            }
            Destroy(gameObject);
        }
    }
}
