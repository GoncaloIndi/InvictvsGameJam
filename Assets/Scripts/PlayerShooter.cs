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

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1) & PauseManager.GetComponent<PauseManager>().GameIsPaused == false && canShoot)
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

        yield return new WaitForSeconds(ShootingCooldown);
        canShoot = true;
        playerMovement.CanMove = true;

    }

}
