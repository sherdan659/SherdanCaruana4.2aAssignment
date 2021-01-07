using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    int waypointIndex = 0;
    WaveConfig waveConfig;
    List<Transform> wayPoints;

    //This bool will ensure that it doesnt move the enemy unless the startwave method is called 
    bool startedwave = false;

    // As soon as the waveconfig is set by the enemyspawner this method will run taking the waypoints from waveconfig to move the objects.

    public void startwave()
    {

        wayPoints = waveConfig.GetWaypoints();
        transform.position = wayPoints[waypointIndex].transform.position;
        startedwave = true;
    }


    void Update()
    {
        if (startedwave == true)
        {

            EnemyMove();
        }
        
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
