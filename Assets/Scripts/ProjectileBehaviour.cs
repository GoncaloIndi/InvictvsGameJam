using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float Speed;

    void Update()
    {
        transform.position += -transform.right * Time.deltaTime * Speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Colidiu");
        Destroy(gameObject);
    }
}
