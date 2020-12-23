using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePathing : MonoBehaviour
{
    [SerializeField] List<Transform> waypointsList;
    [SerializeField] float obstacleSpeed = 0.01f;

    [SerializeField] WaveConfig waveconfig;

    int waypointsIndex = 0;//current waypoint
    
    // Start is called before the first frame update
    void Start()
    {
        waypointsList = waveconfig.GetWaypointsList();

        transform.position = waypointsList[waypointsIndex].transform.position;//set the position of the enemy to position of the 1st waypoint
    }

    // Update is called once per frame
    void Update()
    {
        ObstacleMovement();
    }

    private void ObstacleMovement()
    {
        if (waypointsIndex <= waypointsList.Count - 1)
        {
            //next waypointg
            var targetPosition = waypointsList[waypointsIndex].transform.position;

            targetPosition.z = 0f;

            var obstacleMovement = obstacleSpeed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, obstacleSpeed);

            if (transform.position == targetPosition)
            {
                waypointsIndex++;
            }
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
