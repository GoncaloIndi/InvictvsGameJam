using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseManager;
    private void Awake()
    {
        PauseManager = GameObject.Find("PauseManager");
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        PauseManager.GetComponent<PauseManager>().GameIsPaused = false;
        this.gameObject.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
