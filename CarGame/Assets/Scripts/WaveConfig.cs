using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyWave")]
public class WaveConfig : ScriptableObject
{

    [SerializeField] List<Transform> waypoints;


    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();

    }

    // Update is called once per frame
    void Update()
    {

    }
    [SerializeField] GameObject enemyPrefab;
    //the path on which to go
    [SerializeField] GameObject pathPrefab;
    //number of enemies in the wave
    [SerializeField] int numberOfEnemies = 5;
    //enemy movement speed
    [SerializeField] float enemyMoveSpeed = 2f;

    [SerializeField] WaveConfig waveConfig;



    public List<Transform> GetWaypoints()
    {
        //each wave can have different waypoints
        var waveWayPoints = new List<Transform>();

        //go into Path prefab and for each child, add it to the List waveWaypoints
        foreach (Transform child in pathPrefab.transform)
        {
            waveWayPoints.Add(child);
        }

        return waveWayPoints;
    }

    public GameObject GetPathPrefab()
    {
        return pathPrefab;
    }

    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }

    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }


}
