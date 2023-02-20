using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public Invader[] prefabs;
    public int rows = 5;
    public int columns = 11;
    public AnimationCurve speed;

    public Projectile enemyfirePrefab;

    public int amountKilled { get; private set; }
    public int amountRemaining => this.totalInvaders - this.amountKilled;
    public int totalInvaders => this.rows * this.columns;
    public float percentKilled =>(float) this.amountKilled /(float) this.totalInvaders;

    public float enemyAttackRate = 1.0f;

    private Vector3 _direction = Vector2.right;

    private void Awake()
    {
        for(int row = 0; row < this.rows; row++)
        {
            float width = 3.0f * (this.columns - 1);
            float height = 0f * (this.rows - 1);
            Vector3 centering = new Vector2(-width / 3, -height / 3);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * 1.0f), 0.0f);

            for(int col = 0; col < this.columns; col++)
            {
              Invader invader = Instantiate(this.prefabs[row], this.transform);
                invader.killed += InvaderKilled;
                Vector3 position = rowPosition;
                position.x += col * 2.0f;
                invader.transform.localPosition = position;
            }
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(EnemyAttack), this.enemyAttackRate, this.enemyAttackRate);
    }

    private void Update()
    {
        this.transform.position += _direction * this.speed.Evaluate(this.percentKilled) * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }
            if (_direction == Vector3.right && invader.position.x >= (rightEdge.x - .5f))
            {
                AdvanceRow();
            }
            else if
                (_direction == Vector3.left && invader.position.x <= (leftEdge.x + .5f))
                {
                    AdvanceRow();
                }
            
        }
    }

    private void AdvanceRow()
    {
        _direction.x *= -1.0f;

        Vector3 position = this.transform.position;
        position.y -= 1.0f;
        this.transform.position = position;

    }

    private void EnemyAttack()
    {
        foreach (Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }

            if(Random.value < (1.0f / (float)this.amountRemaining))
            {
                Instantiate(this.enemyfirePrefab, invader.position, Quaternion.identity);
                break;
            }

        }
    }

    private void InvaderKilled()
    {
        this.amountKilled++;

        if(this.amountKilled >= this.totalInvaders)
        {
            SceneManager.LoadScene("Level 2");
        }
    }
}