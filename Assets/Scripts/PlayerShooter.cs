using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public ProjectileBehaviour ProjectilePrefab;
    public Transform LaunchOffset;
    public float ShootingCooldown;
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine("Fire");
        }

    }

    IEnumerator Fire()
    {
        Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);

        yield return new WaitForSeconds(ShootingCooldown);
    }

}
