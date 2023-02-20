using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBullet : MonoBehaviour
{
    public float speed;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(1);

            Destroy(this.gameObject);
        }
        if (collision.tag == "Defense")
        {
           

            Destroy(this.gameObject);
        }
    }
}
