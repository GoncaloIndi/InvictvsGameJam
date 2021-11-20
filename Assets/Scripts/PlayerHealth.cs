using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static int PlayerHP;

    private void Awake()
    {
        PlayerHP = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
