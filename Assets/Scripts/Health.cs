using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    public static event Action OnPlayerDeath;
    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if ( currentHealth <= 0)
        {
            currentHealth = 0;
            GetComponent<Player>().enabled = false;
            OnPlayerDeath?.Invoke();
            Debug.Log("Your Dead");
        }
        
    }
   
}
