using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public CameraScript Camera;

    [SerializeField]
    private int EnemiesLeft;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StopLevel();
    }

    private void StopLevel()
    {
        Camera.AreEnemiesAlive = true;
        StartCoroutine("CheckEnemies");
    }

    private IEnumerator CheckEnemies()
    {
        while(true)
        {
            if(EnemiesLeft <= 0)
            {
                ContinueLevel();
            }
            yield return new WaitForSeconds(.1f);
        }
    }

    private void ContinueLevel()
    {
        Camera.AreEnemiesAlive = false;
        StopCoroutine("CheckEnemies");
    }
}
