using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunLevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] missileActivator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < missileActivator.Length; i++)
        {
            missileActivator[i].SetActive(true);
        }
    }
}
