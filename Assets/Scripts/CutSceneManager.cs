using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneManager : MonoBehaviour
{
    public GameObject DialogueBar;

    public GameObject Dialogue1;
    public GameObject Dialogue2;
    public GameObject Dialogue3;
    public GameObject Dialogue4;
    public GameObject Dialogue5;
    public PlayerMovement startScene;

    public float FirstCutsceneInterval1;
    public float FirstCutsceneInterval2;

    

    public void Start()
    {
        StartCoroutine("FirstCutscene");
    }

    private IEnumerator FirstCutscene()
    {
        DialogueBar.SetActive(true);
        Dialogue1.SetActive(true);

        yield return new WaitForSeconds(FirstCutsceneInterval1);

        Dialogue1.SetActive(false);
        Dialogue2.SetActive(true);

        yield return new WaitForSeconds(FirstCutsceneInterval1);

        Dialogue2.SetActive(false);
        DialogueBar.SetActive(false);
        startScene.StartWalkSequence();

        yield return null;
    }

}
