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
    private GameObject gun;

    [SerializeField]
    private GameObject BulletRightPrefab;

    [SerializeField]
    private GameObject BulletLeftPrefab;

    [SerializeField]
    private bool IsShootingLeft = true;

    public LevelManager EnemyCount;

    [SerializeField]
    private Animator enemyAnim;

    public void StartShooting()
    {
        betweenShotsDelay = .5f;
        enemyAnim.SetFloat("hasStopped", 1f);
        StartCoroutine("Shoot");
        if(!IsShootingLeft)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(this.gameObject.transform.rotation.x, 180, this.gameObject.transform.rotation.z);
        }
        
    }

    public void OnDeath()
    {
        EnemyCount.EnemiesLeft--;
        EnemyCount.CheckEnemies();
        nextEnemy.SetActive(true);
        nextTrigger.SetActive(true);
        StopCoroutine("Shoot");
        enemyAnim.SetTrigger("Death");
    }
    

    private IEnumerator Shoot()
    {
        while(true)
        {
            yield return new WaitForSeconds(betweenShotsDelay);
            betweenShotsDelay = Random.Range(1.5f, 3f);
            enemyAnim.SetTrigger("Shoot");
            if(IsShootingLeft)
            {
                Instantiate(BulletLeftPrefab, gun.transform.position, this.gameObject.transform.rotation);
            }
            else
            {
                Instantiate(BulletRightPrefab, gun.transform.position, this.gameObject.transform.rotation);
            }
            
            

        }
    }
    
}
