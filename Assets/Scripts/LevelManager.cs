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
            ContinueLevel();
        }
    }

    private void ContinueLevel()
    {
        Camera.AreEnemiesAlive = false;
        borders.SetActive(false);
    }
}
