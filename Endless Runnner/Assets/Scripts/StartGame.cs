using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{

    public GameObject movement;
    public GameObject nab;
    public GameObject nabSpawner;
    public GameObject obstacleSpawner;
    public GameObject canvas;
    public GameObject[] startObs;

    public void Play()
    {
        movement.GetComponent<Movement>().start = true;
        nab.GetComponent<NAB>().start = true;
        nabSpawner.GetComponent<NABSpawner>().start = true;
        obstacleSpawner.GetComponent<ObstaclesSpawner>().start = true;
        obstacleSpawner.GetComponent<ObstaclesSpawner>().time = obstacleSpawner.GetComponent<ObstaclesSpawner>().spawnEvery;
        foreach(GameObject obs in startObs)
        {
            obs.SetActive(true);
        }
        Destroy(canvas);
    }
}
