using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemyContainer;
    
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            var posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            var newEnemy = Instantiate(enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }
}
