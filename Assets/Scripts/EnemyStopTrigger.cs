using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyStopTrigger : MonoBehaviour
{
    [SerializeField]
    private UnityEvent stopTrigger;
    [SerializeField]
    private bool hasDoneIt = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!hasDoneIt)
        {
            hasDoneIt = true;
            stopTrigger.Invoke();
        }
        
    }
}
