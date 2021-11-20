using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static int PlayerHP;

    [SerializeField]
    private GameObject[] damageScreens;

    private int hpStorer;

    private void Awake()
    {
        PlayerHP = 3;
        hpStorer = PlayerHP;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerHP < 0)
        {
            Destroy(this.gameObject);
        }
        if(PlayerHP != hpStorer)
        {
            UpdateOverlays();
        }

    }

    public void UpdateOverlays()
    {
        if(PlayerHP == 3)
        {
            damageScreens[0].SetActive(false);
            damageScreens[1].SetActive(false);
            damageScreens[2].SetActive(false);
        }
        else if(PlayerHP == 2)
        {
            damageScreens[0].SetActive(true);
            damageScreens[1].SetActive(false);
            damageScreens[2].SetActive(false);
        }
        else if (PlayerHP == 1)
        {
            damageScreens[0].SetActive(true);
            damageScreens[1].SetActive(true);
            damageScreens[2].SetActive(false);
        }
        else if (PlayerHP == 0)
        {
            damageScreens[0].SetActive(true);
            damageScreens[1].SetActive(true);
            damageScreens[2].SetActive(true);
            //Ligar menu
        }
    }
}
