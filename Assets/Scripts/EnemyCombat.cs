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
    private Rigidbody2D rb;

    [SerializeField]
    private bool IsShootingLeft = true;

    [SerializeField]
    private bool isLastEnemy = false;

    public LevelManager EnemyCount;

    public EnemyMovement Stop;

    private bool isAlive = true;

    [SerializeField]
    private Animator enemyAnim;

    private SoundManager SoundManager;

    private void Start()
    {
        SoundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

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
        this.gameObject.layer = 12;
        Stop.StopMoving();
        EnemyCount.EnemiesLeft--;
        EnemyCount.CheckEnemies();
        
        if(!isLastEnemy)
        {
            nextEnemy.SetActive(true);
            nextTrigger.SetActive(true);
        }

        isAlive = false;
        enemyAnim.SetTrigger("Death");
        Destroy(this);
    }
    

    private IEnumerator Shoot()
    {
        while(isAlive)
        {
            yield return new WaitForSeconds(betweenShotsDelay);
            betweenShotsDelay = Random.Range(1.5f, 3.5f);
            enemyAnim.SetTrigger("Shoot");
            SoundManager.PlaySound("Fire");
            if (IsShootingLeft)
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
