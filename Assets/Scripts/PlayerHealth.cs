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

    public PlayerMovement notMoveJustDie;

    [SerializeField]
    private Animator anim;

    private void Awake()
    {
        PlayerHP = 3;
        hpStorer = PlayerHP;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerHP != hpStorer)
        {
            UpdateOverlays();
        }
        hpStorer = PlayerHP;

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
            anim.SetTrigger("Damage");
            damageScreens[0].SetActive(true);
            damageScreens[1].SetActive(false);
            damageScreens[2].SetActive(false);
        }
        else if (PlayerHP == 1)
        {
            anim.SetTrigger("Damage");
            damageScreens[0].SetActive(true);
            damageScreens[1].SetActive(true);
            damageScreens[2].SetActive(false);
        }
        else if (PlayerHP == 0)
        {
            anim.SetTrigger("Damage");
            damageScreens[0].SetActive(true);
            damageScreens[1].SetActive(true);
            damageScreens[2].SetActive(true);
            //Ligar menu
            
        }
        else if (PlayerHP <= -1 && PlayerHP > -50)
        {
            anim.SetTrigger("Damage");
            notMoveJustDie.MovementSpeed = 0;
            damageScreens[3].SetActive(true);
        }
        else if (PlayerHP <= -50)
        {
            anim.SetTrigger("Missile");
        }
    }

    public void ToggleDeadScreen()
    {
        Debug.Log("boo");
        damageScreens[3].SetActive(true);
        notMoveJustDie.CanMove = false;
    }
}
