using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    [SerializeField]
    private GameObject quoteSpawn;

    [SerializeField]
    private GameObject houseDispawn;

    public PlayerMovement Cutscene;

    [SerializeField]
    private GameObject runOne;

    [SerializeField]
    private GameObject runTwo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        houseDispawn.SetActive(false);
        runTwo.SetActive(false);
        runOne.SetActive(false);
        quoteSpawn.SetActive(true);
        Cutscene.StartEndThing();
    }
}
