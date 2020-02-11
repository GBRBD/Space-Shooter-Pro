using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemyContainer;
    [SerializeField] private GameObject[] powerUps;

    private bool _stopSpawning = false;

    private void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        while (_stopSpawning == false)
        {
            var posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            var newEnemy = Instantiate(enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = enemyContainer.transform;

            yield return new WaitForSeconds(5.0f);
        }
    }

    private IEnumerator SpawnPowerUpRoutine()
    {
        while (_stopSpawning == false)
        {
            var posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            int randomPowerUp = Random.Range(0, powerUps.Length);
            Instantiate(powerUps[randomPowerUp], posToSpawn, Quaternion.identity);

            yield return new WaitForSeconds(Random.Range(3, 9));
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}