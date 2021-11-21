using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField]
    private float xOffset;

    [SerializeField]
    private Rigidbody2D missileRB;

    [SerializeField]
    private GameObject explosionPrefab;

    [SerializeField]
    private float missileRadius;

    [SerializeField]
    private float missileSpeed;

    [SerializeField]
    private LayerMask playerLayer;

    private SoundManager SoundManager;

    


    // Start is called before the first frame update
    void Start()
    {
        xOffset = Random.Range(-.3f, .3f);
        missileSpeed = Random.Range(5f, 6f);
        missileRB.velocity = new Vector2(xOffset * missileSpeed, -missileSpeed);
        SoundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundManager.PlaySound("BombExplosion");

        Collider2D playerCol = Physics2D.OverlapCircle(this.gameObject.transform.position, missileRadius, playerLayer);
        if(playerCol != null)
        {
            PlayerHealth.PlayerHP = -69;
        }
        Instantiate(explosionPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
        Destroy(this.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.gameObject.transform.position, missileRadius);
    }
}
