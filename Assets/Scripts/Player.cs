using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Projectile firePrefab;

    public float speed = 5.0f;

    private bool _fireActive;

    

    private void Update()
    {


        if (!PauseMenu.isPaused)
        {
            if (Input.GetKey(KeyCode.A))
            {
                this.transform.position += Vector3.left * this.speed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                this.transform.position += Vector3.right * this.speed * Time.deltaTime;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
        }
        
    }

    private void Shoot()
    {
        if (!_fireActive)
        {
            Projectile projectile = Instantiate(this.firePrefab, this.transform.position, Quaternion.identity);
            projectile.destroyed += FireDestroyed;
            _fireActive = true;
        }
    }

    private void FireDestroyed()
    {
        _fireActive = false;
    }


}
