using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePathing : MonoBehaviour
{
    [SerializeField] List<Transform> waypointsList;
    [SerializeField] float obstMoveSpeed = 0.5f;
    [SerializeField] WaveConfig waveConfig;

    int waypointsIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        waypointsList = waveConfig.GetWaypointsList();
        
        transform.position = waypointsList[waypointsIndex].transform.position;
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
            var targetPosition = waypointsList[waypointsIndex].transform.position;

            targetPosition.z = 0f;

            var obstacleMovement = waveConfig.GetObstMoveSpeed() * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, obstacleMovement);

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

    public void SetWaveConfig(WaveConfig waveConfigToSet)
    {
        waveConfig = waveConfigToSet;
    }
}
