using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{

    int waypointIndex = 0;
    WaveConfig waveConfig;
    List<Transform> wayPoints;



    void Start()
    {
        wayPoints = waveConfig.GetWaypoints();
        transform.position = wayPoints[waypointIndex].transform.position;
    }


    void Update()
    {
        EnemyMove();
        
        
    }
    

    void EnemyMove()
    {
        if (waypointIndex <= wayPoints.Count - 1)
        {
            var targetPosition = wayPoints[waypointIndex].transform.position;
            var movementThisFrame = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;
            targetPosition.z = 0f;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }


    }
    public void SetWaveConfig(WaveConfig waveConfigToSet)
    {
        waveConfig = waveConfigToSet;
    }

}
