using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseManager : MonoBehaviour
{
    public bool GameIsPaused;
    public GameObject PauseMenu;

    private void Update()
    {
        if (!GameIsPaused & Input.GetKeyDown(KeyCode.Escape))
        {
            GameIsPaused = true;
            Time.timeScale = 0f;
            PauseMenu.SetActive(true);
        }
        else if (GameIsPaused & Input.GetKeyDown(KeyCode.Escape))
        {
            GameIsPaused = false;
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
        }
    }
}
