using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Obstacle_Wave")]
public class ObstacleWaveScript : ScriptableObject
{
    
    [SerializeField] GameObject ObstaclePrefabSpawn;
    //the path on which to go
    [SerializeField] GameObject PathPrefabMove;
    //number of enemies in the wave
    [SerializeField] int numberOfObsticales = 2;
    //enemy movement speed
    [SerializeField] float ObstacleMovmentSpeed = 2f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject GetEnemyPrefab()
    {
        return ObstaclePrefabSpawn;
    }

    public List<Transform> GetPathPrefab()
    {
        var waveWayPoints = new List<Transform>();
        foreach (Transform child in PathPrefabMove.transform)
        {
            waveWayPoints.Add(child);
        }
            return waveWayPoints;
    }

    public int GetNumberOfEnemies()
    {
        return numberOfObsticales;
    }

    public float GetEnemyMoveSpeed()
    {
        return ObstacleMovmentSpeed;
    }

}
