using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public ProjectileBehaviour ProjectilePrefab;
    public Transform LaunchOffset;
    public float ShootingCooldown;
    private bool canShoot = true;
    public GameObject PauseManager;
    private PlayerMovement playerMovement;

    public Animator animator;
    private SoundManager SoundManager;



    private void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        SoundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) & PauseManager.GetComponent<PauseManager>().GameIsPaused == false && canShoot)
        {
            StartCoroutine("Fire");
        }

    }

    IEnumerator Fire()
    {
        canShoot = false;
        playerMovement.CanMove = false;
        animator.SetTrigger("Fire");
        Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
        SoundManager.PlaySound("Fire");
        yield return new WaitForSeconds(.2f);
        playerMovement.CanMove = true;

        yield return new WaitForSeconds(ShootingCooldown);
        canShoot = true;
        

    }

}
