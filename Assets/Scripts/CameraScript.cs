using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private Transform playerPosistion;

    [SerializeField]
    private bool areEnemiesAlive;

    [SerializeField]
    private Vector3 offset;

    [SerializeField]
    [Range(1, 10)]
    private float smoothness;

    private void FixedUpdate()
    {
        if (!areEnemiesAlive)
        {
            FollowPlayer();
        }

    }

    private void FollowPlayer()
    {
        Vector3 newPosition = playerPosistion.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, newPosition, smoothness*Time.fixedDeltaTime);
        transform.position = new Vector3(smoothPosition.x, transform.position.y, transform.position.z);
    }
}
