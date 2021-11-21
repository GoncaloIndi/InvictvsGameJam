using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveUpUi : MonoBehaviour
{
    [SerializeField]
    private GameObject ReturnUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ReturnUI.SetActive(true);
    }
}
