using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public CameraScript Camera;

    public int EnemiesLeft;

    [SerializeField]
    private GameObject borders;

    [SerializeField]
    private GameObject runOne;

    [SerializeField]
    private GameObject runTwo;

    [SerializeField]
    private GameObject win;

    [SerializeField]
    private GameObject trigger;

    [SerializeField]
    private bool isLastLevel = false;

    [SerializeField]
    private GameObject[] firstEnemy;

    [SerializeField]
    private bool hasBeenTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!hasBeenTriggered)
        {
            hasBeenTriggered = true;
            StopLevel();
            for (int i = 0; i < firstEnemy.Length; i++)
            {
                firstEnemy[i].SetActive(true);
            }

        }
        
    }

    private void StopLevel()
    {
        Camera.AreEnemiesAlive = true;
        borders.SetActive(true);
    }



    public void CheckEnemies()
    {
        if (EnemiesLeft <= 0)
        {
            if(isLastLevel)
            {
                runOne.SetActive(false);
                runTwo.SetActive(false);
                win.SetActive(true);
                trigger.SetActive(true);
            }
            ContinueLevel();
        }
    }

    private void ContinueLevel()
    {
        Camera.AreEnemiesAlive = false;
        borders.SetActive(false);
    }
}
