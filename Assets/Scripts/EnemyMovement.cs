using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float enemySpeed;

    [SerializeField]
    private Rigidbody2D enemyRB;

    private bool canMove = true;

    private void Update()
    {
        if(canMove)
        {
            enemyRB.velocity = new Vector2(-enemySpeed, 0);
        }
        
    }

    public void StopMoving()
    {
        canMove = false;
        enemyRB.velocity = new Vector2(0 , 0);
    }
}
