using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnController : MonoBehaviour {
    public float minimalSpawnDistance = 15f;

    public float maximumSpawnDistance = 25f;

    public int waveNumber = 1;

    public GameObject enemyPrefab;
    
    public TextMeshProUGUI waveDisplay;

    private int _enemiesAlive = 0;

    // Start is called before the first frame update
    private void Start() {
        SpawnWave();
    }
    
    private void SpawnWave() {
        if (_enemiesAlive != 0) return;
        
        waveDisplay.SetText("Wave: {0}", waveNumber);
        var currentPlayerPosition = transform.position;

        for (var i = 0; i < waveNumber + 3; i++) {
            SpawnEnemy(currentPlayerPosition);
        }

        waveNumber++;
    }
    
    private void SpawnEnemy(Vector3 currentPlayerPosition) {
        var xPositiveOrNegative = Random.Range(0, 2) == 0 ? -1 : 1;
        var zPositiveOrNegative = Random.Range(0, 2) == 0 ? -1 : 1;

        var spawnPosition = currentPlayerPosition - new Vector3(
            xPositiveOrNegative * Random.Range(minimalSpawnDistance, maximumSpawnDistance),
            0,
            zPositiveOrNegative * Random.Range(minimalSpawnDistance, maximumSpawnDistance));

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        _enemiesAlive++;
    }

    public void EnemyGotHit() {
        _enemiesAlive--;
        if (_enemiesAlive == 0) {
            SpawnWave();
        }
    }
}