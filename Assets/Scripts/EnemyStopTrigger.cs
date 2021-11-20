using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyStopTrigger : MonoBehaviour
{
    [SerializeField]
    private UnityEvent stopTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        stopTrigger.Invoke();
    }
}
