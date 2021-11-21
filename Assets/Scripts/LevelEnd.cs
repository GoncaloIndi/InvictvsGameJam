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
    private GameObject levels;

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
        Cutscene.StartEndThing();
        menu.SetActive(false);
    }
}
