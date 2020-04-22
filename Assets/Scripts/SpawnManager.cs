using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 3, 3);
;    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        Instantiate(enemyPrefab, -playerObject.transform.position, enemyPrefab.transform.rotation);
    }
}
