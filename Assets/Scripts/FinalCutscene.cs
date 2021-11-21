using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCutscene : MonoBehaviour
{
    [SerializeField]
    private GameObject WinUi;

    [SerializeField]
    private GameObject frase1;
    [SerializeField]
    private GameObject frase2;
    [SerializeField]
    private GameObject frase3;

    public GameObject backToMenu;

    [SerializeField]
    Animator animator;
    [SerializeField]
    GameObject perso;
    private bool walking = false;
    private bool walkingcar = false;

    [SerializeField]
    private float speed = -2;

    

    [SerializeField]
    private float sec = 2f;

    private int i = 0;

    bool walk2 = false;

    bool walkcar = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        WinUi.SetActive(false);
        collision.gameObject.SetActive(false);
        StartFinalCutscene();
    }

    private void StartFinalCutscene()
    {
        StartCoroutine("cutscene2");
    }

    // Update is called once per frame
    void Start()
    {
        frase1.SetActive(false);
        frase2.SetActive(false);
        frase3.SetActive(false);
    }

    void Update()
    {


        if (this.transform.position.x <= -14)
        {
            Debug.Log("stopp");
            animator.SetBool("IsRunning", false);
            walk2 = false;
            walking = false;
        }

        if (perso.transform.position.x >= -7)
        {
            animator.SetBool("IsCrib", false);
            walkcar = false;
            walkingcar = false;
        }


    }

    void FixedUpdate()
    {
        if (walk2)
        {
            perso.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed / 20, 0), ForceMode2D.Impulse);
        }

        if (walkcar)
        {
            perso.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed / -20, 0), ForceMode2D.Impulse);
        }
    }

    public IEnumerator cutscene2()
    {

        frase1.SetActive(true);
        yield return new WaitForSeconds(sec);
        frase1.SetActive(false);
        frase2.SetActive(true);
        yield return new WaitForSeconds(sec);
        frase2.SetActive(false);
        //Start Baby cries sound//
        frase3.SetActive(true);
        yield return new WaitForSeconds(1);
        frase3.SetActive(false);
        backToMenu.SetActive(true);
        


    }

  
}
