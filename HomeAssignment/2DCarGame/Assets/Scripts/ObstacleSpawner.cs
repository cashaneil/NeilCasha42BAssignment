using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigsList;

    [SerializeField] bool looping = false;

    int startingWave = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        } while (looping == true);

        StartCoroutine(SpawnAllWaves());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveToSpawn)
    {
        for (int obstacleCount = 1; obstacleCount <= waveToSpawn.GetNoOfObstacles(); obstacleCount++)
        {
            var newObst = Instantiate(
                waveToSpawn.GetObstaclePrefab(),
                waveToSpawn.GetWaypointsList()[0].transform.position,
                Quaternion.identity) as GameObject;

            newObst.GetComponent<ObstaclePathing>().SetWaveConfig(waveToSpawn);

            yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenSpawns());
        }
    }

    private IEnumerator SpawnAllWaves()
    {
        foreach (WaveConfig currentWave in waveConfigsList)
        {
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }
}
