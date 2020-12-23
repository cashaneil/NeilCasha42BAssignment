using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Obstacle Wave Config")]

public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float timeBetweenSpawns = 1f;
    [SerializeField] int noOfObstacles = 2;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float obstacleMoveSpeed = 0.01f;

    public GameObject GetObstaclePrefab()
    {
        return obstaclePrefab;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public int GetNoOfObstacles()
    {
        return noOfObstacles;
    }

    public GameObject GetPathPrefab()
    {
        return pathPrefab;
    }

    public float GetObstMoveSpeed()
    {
        return obstacleMoveSpeed;
    }

    public List<Transform> GetWaypointsList()
    {
        var waypoints = new List<Transform>(); //list which holds each path

        foreach (Transform child in pathPrefab.transform) //for each waypoint in each path of the list
        {
            waypoints.Add(child);
        }

        return waypoints;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
