using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField]
    private float betweenShotsDelay;

    [SerializeField]
    private GameObject BulletPrefab;

    public void StartShooting()
    {
        betweenShotsDelay = Random.Range(1.5f, 3f);
        StartCoroutine("Shoot");
        
    }

    private IEnumerator Shoot()
    {
        while(true)
        {
            betweenShotsDelay = Random.Range(1.5f, 3f);
            yield return new WaitForSeconds(betweenShotsDelay);
            Instantiate(BulletPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);          
            
        }
    }
    
}
