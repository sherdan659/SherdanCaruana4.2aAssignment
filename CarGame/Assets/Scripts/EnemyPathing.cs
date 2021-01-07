using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    int waypointIndex = 0;

    [SerializeField] List<Transform> path;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = path[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    void EnemyMove()
    {
        if (waypointIndex <= path.Count - 1)
        {
            var targetPosition = path[waypointIndex].transform.position;

            targetPosition.z = 0f;

            var movementThisFrame = moveSpeed * Time.deltaTime;
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
}
