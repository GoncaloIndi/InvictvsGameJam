using System.Collections;
using UnityEngine;

public class CutSceneManager : MonoBehaviour
{
    public GameObject DialogueBar;

    public GameObject Dialogue1;
    public GameObject Dialogue2;
    public GameObject Dialogue3;
    public GameObject Dialogue4;
    public GameObject Dialogue5;

    public float FirstCutsceneInterval1;
    public float FirstCutsceneInterval2;

    public float SecondCutsceneInterval1;
    public float SecondCutsceneInterval2;
    public float SecondCutsceneInterval3;





    public void StartFirstCutscene()
    {
        StartCoroutine("FirstCutscene");
    }

    public void StartSecondCutscene()
    {
        StartCoroutine("SecondCutscene");
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

        yield return null;
    }
    private IEnumerator SecondCutscene()
    {
        DialogueBar.SetActive(true);
        Dialogue3.SetActive(true);

        yield return new WaitForSeconds(SecondCutsceneInterval1);

        Dialogue3.SetActive(false);
        Dialogue4.SetActive(true);

        yield return new WaitForSeconds(SecondCutsceneInterval2);

        Dialogue4.SetActive(false);
        Dialogue5.SetActive(true);

        yield return new WaitForSeconds(SecondCutsceneInterval3);

        Dialogue5.SetActive(false);
        DialogueBar.SetActive(false);
    
        yield return null;
    }

}
