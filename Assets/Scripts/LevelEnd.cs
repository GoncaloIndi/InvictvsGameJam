using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    [SerializeField]
    private GameObject quoteSpawn;

    [SerializeField]
    private GameObject houseDispawn;

    [SerializeField]
    private GameObject menu;

    [SerializeField]
    private GameObject finalTrigger;

    [SerializeField]
    private GameObject levels;

    private bool hasTriggered = false;

    [SerializeField]
    private GameObject MusicEpic;

    [SerializeField]
    private GameObject MusicSad;

    [SerializeField]
    private GameObject levelsTwo;

    [SerializeField]
    private Transform player;

    public CameraScript followPlayer;

    public PlayerMovement Cutscene;

    public void GiveUp()
    {
        player.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        Rigidbody2D rigidbody = player.gameObject.GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0;
        player.gameObject.layer = 4;
        followPlayer.AreEnemiesAlive = false;
        levels.SetActive(false);
        MusicEpic.SetActive(false);
        MusicSad.SetActive(true);
        levelsTwo.SetActive(false);
        houseDispawn.SetActive(false);      
        quoteSpawn.SetActive(true);
        menu.SetActive(false);
        Cutscene.StartEndThing();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!hasTriggered)
        {
            finalTrigger.SetActive(true);
            MusicEpic.SetActive(false);
            quoteSpawn.SetActive(true);
            MusicSad.SetActive(true);
            levels.SetActive(false);
            levelsTwo.SetActive(false);
            houseDispawn.SetActive(false);
            followPlayer.AreEnemiesAlive = false;
            hasTriggered = true;
        }

       
        
    }
}
