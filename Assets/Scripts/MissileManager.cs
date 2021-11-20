using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileManager : MonoBehaviour
{
    [SerializeField]
    private GameObject missilePrefab;

    [SerializeField]
    private int spawnRNG;

    private void Start()
    {
        StartCoroutine("SpawnMissiles");
    }

    private IEnumerator SpawnMissiles()
    {
        while(true)
        {
            spawnRNG = Random.Range(0, 8);
            if(spawnRNG == 1)
            {
                Instantiate(missilePrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
            }
            yield return new WaitForSeconds(1);
        }
    }
}
