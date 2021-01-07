using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //a list of WaveConfigs
    [SerializeField] List<WaveConfig> waveConfigs;

    //we always start  from Wave 0
    int startingWave = 0;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        
    }



}
