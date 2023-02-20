using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI shipsLeft;
    List<EnemyHealth> enemies = new List<EnemyHealth>();

    private void OnEnable()
    {
        EnemyHealth.OnEnemyKilled += HandleEnemyDefeated;
        
    }
    private void OnDisable()
    {
        EnemyHealth.OnEnemyKilled -= HandleEnemyDefeated;
       
    }
    private void Awake()
    {
        enemies = GameObject.FindObjectsOfType<EnemyHealth>().ToList();
        UpdateEnemiesLeftText();
        
    }

    void HandleEnemyDefeated(EnemyHealth enemy)
    {
       if (enemies.Remove(enemy))
        {
            UpdateEnemiesLeftText();
        }
        
    }

    void UpdateEnemiesLeftText()
    {
        shipsLeft.text = $"Ships Left:{enemies.Count}";
    }

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            SceneManager.LoadScene("Win");
        }
    }

}
