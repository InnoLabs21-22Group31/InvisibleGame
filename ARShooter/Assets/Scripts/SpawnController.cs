using System.Collections;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class SpawnController : MonoBehaviour {
    public float minimalSpawnDistance = 15f;

    public float maximumSpawnDistance = 25f;

    public float waveNumber = 0;

    public GameObject enemyPrefab;

    public int timeBetweenWaves = 15;

    // Start is called before the first frame update
    private void Start() {
        StartCoroutine(SpawnWaves());
    }

    public IEnumerator SpawnWaves() {
        while (true) {
            var currentPlayerPosition = transform.position;

            for (var i = 0; i < waveNumber + 3; i++) {
                SpawnEnemy(currentPlayerPosition);
            }

            waveNumber++;
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    private void SpawnEnemy(Vector3 currentPlayerPosition) {
        var xPositiveOrNegative = Random.Range(0, 2) == 0 ? -1 : 1;
        var zPositiveOrNegative = Random.Range(0, 2) == 0 ? -1 : 1;

        var spawnPosition = currentPlayerPosition - new Vector3(
            xPositiveOrNegative * Random.Range(minimalSpawnDistance, maximumSpawnDistance),
            0,
            zPositiveOrNegative * Random.Range(minimalSpawnDistance, maximumSpawnDistance));

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}