using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //A used list of WaveConfigs.
    [SerializeField] List<WaveConfig> waveConfigs;

    //we always start  from Wave 0
    int startingWave = 0;

    //Loops the waves
    [SerializeField] bool looping = false;

    IEnumerator Start()
    {
        
        //set the currentWave to the 1st Wave --> 0
        var currentWave = waveConfigs[startingWave];

        //start the coroutine that spawns all enemies in our currentWave

        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
    }

    // Update is called once per frame
    void Update()
    {

    }


    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        //spawns an enemy until enemyCount == GetNumberOfEnemies()
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            //spawn the enemy from waveConfig
            //at the position specified by the waveConfig waypoints
            var newenemy = Instantiate(
                waveConfig.GetEnemyPrefab(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);

            newenemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);

            //This will start EnemyPathing allowing the waypoints to be used from the already created Waveconfig.
            newenemy.GetComponent<EnemyPathing>().startwave();


            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }

    }
    private IEnumerator SpawnAllWaves()
    {
        //this will loop from startingWave until we reach the last within our List
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            //the coroutine will wait for all enemies in Wave to spawn
            //before yielding and going to the next loop
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }


}

