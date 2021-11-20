using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField]
    private float betweenShotsDelay;

    [SerializeField]
    private GameObject nextEnemy;

    [SerializeField]
    private GameObject nextTrigger;

    [SerializeField]
    private GameObject BulletRightPrefab;

    [SerializeField]
    private GameObject BulletLeftPrefab;

    [SerializeField]
    private bool IsShootingLeft = true;

    public LevelManager EnemyCount;

    public void StartShooting()
    {
        betweenShotsDelay = .5f;
        StartCoroutine("Shoot");
        
    }

    public void OnDeath()
    {
        EnemyCount.EnemiesLeft--;
        EnemyCount.CheckEnemies();
        nextEnemy.SetActive(true);
        nextTrigger.SetActive(true);
    }
    

    private IEnumerator Shoot()
    {
        while(true)
        {
            yield return new WaitForSeconds(betweenShotsDelay);
            betweenShotsDelay = Random.Range(1.5f, 3f);

            if(IsShootingLeft)
            {
                Instantiate(BulletLeftPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
            }
            else
            {
                Instantiate(BulletRightPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
            }
            
            

        }
    }
    
}
