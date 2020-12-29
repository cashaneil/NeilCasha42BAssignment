using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> WaveConfigsList; //list of waves
    
    int startingWave = 0; //0 = wave(1)
    
    // Start is called before the first frame update
    void Start()
    {
        var currentWave = WaveConfigsList[startingWave];

        StartCoroutine(SpawnAllObstInWave(currentWave));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnAllObstInWave(WaveConfig waveconfig) //which wave to spawn
    {
        Instantiate(
            waveconfig.GetObstaclePrefab(),
            waveconfig.GetWaypointsList()[0].transform.position,
        Quaternion.identity);

        yield return new WaitForSeconds(waveconfig.GetTimeBetweenSpawns());
    }
}
