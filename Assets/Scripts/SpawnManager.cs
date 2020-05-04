using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public GameObject playerObject;
    public float randRange = 9;
    public int waveNumber = 1;
    private int enemyCount;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if (enemyCount == 0)
        {
            Debug.Log(waveNumber);
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenSpawnPos(), powerupPrefab.transform.rotation);
            waveNumber++;
        }
    }

    private Vector3 GenSpawnPos()
    {
        float spawnX = Random.Range(-randRange, randRange);
        float spawnZ = Random.Range(-randRange, randRange);
        Vector3 pos = new Vector3(spawnX, 0, spawnZ);
        return pos;
    }

    private void SpawnEnemyWave(int numberEnemies)
    {
        for (int en = 0; en < numberEnemies; en++)
        {
            Instantiate(enemyPrefab, GenSpawnPos(), enemyPrefab.transform.rotation);
        }
    }
}
