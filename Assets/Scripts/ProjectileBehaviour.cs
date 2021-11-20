using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float Speed;

    public EnemyCombat DeathTrigger;

    [SerializeField]
    private Rigidbody2D rb;

    void Start()
    {
        rb.velocity = new Vector2(Speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Colidiu");
        if(other.gameObject.CompareTag("Enemy"))
        {
            DeathTrigger = other.gameObject.GetComponent<EnemyCombat>();
            DeathTrigger.OnDeath();
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject, 3f);
        }
        
    }
}
