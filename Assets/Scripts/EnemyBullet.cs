using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed;

    [SerializeField]
    private Rigidbody2D bulletRB;

    // Start is called before the first frame update
    void Start()
    {
        bulletRB.velocity = new Vector2(-bulletSpeed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth.PlayerHP--;
        }

        Destroy(this.gameObject);
    }
}
