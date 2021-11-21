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

    public void GiveUp()
    {
        houseDispawn.SetActive(false);
        quoteSpawn.SetActive(true);
        Cutscene.StartEndThing();
    }
}
