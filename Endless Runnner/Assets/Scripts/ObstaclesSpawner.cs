using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject obsCloneHolder;
    public Transform[] obsLocation;
    public float spawnEvery = 2f;
    public float percentageDecrease = 0.95f;
    public float time;
    public List<GameObject> obsSpawn = new List<GameObject>();

    public int score = 0;
    public int scoreStage2 = 100;
    public int scoreStage3 = 300;
    public bool start;

    void Start()
    {
        time = spawnEvery;
    }
    void FixedUpdate()
    {
        time -= Time.deltaTime;
        if (time <= 0 && start)
        {
            if (score >= scoreStage3)
            {
                int rnd = Random.Range(3, 18);
                switch(rnd)
                {
                    case 3:Type3();break;
                    case 4:Type4();break;
                    case 5:Type5();break;
                    case 6:Type6();break;
                    case 7:Type7();break;
                    case 8:Type8();break;
                    case 9:Type9();break;
                    case 10:Type10();break;
                    case 11:Type11();break;
                    case 12:Type12();break;
                    case 13:Type13(); break;
                    case 14:Type14();break;
                    case 15:Type15();break;
                    case 16:Type16();break;
                    case 17:Type17();break;
                }

                if(score%50 == 0 && score != scoreStage3)
                {
                    spawnEvery *= percentageDecrease;
                }
            }
            else if(score >= scoreStage2)
            {
                int rnd = Random.Range(1, 12);
                switch (rnd)
                {
                    case 1: Type1(); break;
                    case 2: Type2(); break;
                    case 3: Type3(); break;
                    case 4: Type4(); break;
                    case 5: Type5(); break;
                    case 6: Type6(); break;
                    case 7: Type7(); break;
                    case 8: Type8(); break;
                    case 9: Type9(); break;
                    case 10: Type10(); break;
                    case 11: Type11(); break;
                }
            }
            else
            {
                int rnd = Random.Range(1, 6);
                switch (rnd)
                {
                    case 1: Type1(); break;
                    case 2: Type2(); break;
                    case 3: Type3(); break;
                    case 4: Type4(); break;
                    case 5: Type5(); break;
                }
            }
            time = spawnEvery;
        } 
    }
    void Type1()
    {
        SpawnDown(obsLocation[1]);
        SpawnDown(obsLocation[3]);
        SpawnDown(obsLocation[5]);
    }
    void Type2()
    {
        SpawnUp(obsLocation[0]);
        SpawnUp(obsLocation[2]);
        SpawnUp(obsLocation[4]);
    }
    void Type3()
    {
        SpawnMid(obsLocation[1]);
        SpawnMid(obsLocation[3]);
    }
    void Type4()
    {
        SpawnMid(obsLocation[3]);
        SpawnMid(obsLocation[5]);
    }
    void Type5()
    {
        SpawnMid(obsLocation[1]);
        SpawnMid(obsLocation[5]);
    }
    void Type6()
    {
        SpawnMid(obsLocation[1]);
        SpawnUp(obsLocation[2]);
        SpawnUp(obsLocation[4]);
    }
    void Type7()
    {
        SpawnMid(obsLocation[5]);
        SpawnUp(obsLocation[0]);
        SpawnUp(obsLocation[2]);
    }
    void Type8()
    {
        SpawnMid(obsLocation[3]);
        SpawnUp(obsLocation[0]);
        SpawnUp(obsLocation[4]);
    }
    void Type9()
    {
        SpawnMid(obsLocation[1]);
        SpawnDown(obsLocation[3]);
        SpawnDown(obsLocation[5]);
    }
    void Type10()
    {
        SpawnMid(obsLocation[5]);
        SpawnDown(obsLocation[1]);
        SpawnDown(obsLocation[3]);
    }
    void Type11()
    {
        SpawnMid(obsLocation[3]);
        SpawnDown(obsLocation[1]);
        SpawnDown(obsLocation[5]);
    }
    void Type12()
    {
        SpawnMid(obsLocation[1]);
        SpawnMid(obsLocation[3]);
        SpawnUp(obsLocation[4]);
    }
    void Type13()
    {
        SpawnMid(obsLocation[3]);
        SpawnMid(obsLocation[5]);
        SpawnUp(obsLocation[0]);
    }
    void Type14()
    {
        SpawnMid(obsLocation[1]);
        SpawnMid(obsLocation[5]);
        SpawnUp(obsLocation[2]);
    }
    void Type15()
    {
        SpawnMid(obsLocation[1]);
        SpawnMid(obsLocation[3]);
        SpawnDown(obsLocation[5]);
    }
    void Type16()
    {
        SpawnMid(obsLocation[3]);
        SpawnMid(obsLocation[5]);
        SpawnDown(obsLocation[1]);
    }
    void Type17()
    {
        SpawnMid(obsLocation[1]);
        SpawnMid(obsLocation[5]);
        SpawnDown(obsLocation[3]);
    }
    void SpawnUp(Transform location)
    {
        GameObject babyObstacle = Instantiate(obstacles[0], location.position, Quaternion.Euler(0, 0, 0));
        babyObstacle.AddComponent<Obstacles>();
        babyObstacle.tag = "Obstacle";
        obsSpawn.Add(babyObstacle);
        babyObstacle.transform.parent = obsCloneHolder.transform;
    }
    void SpawnDown(Transform location)
    {
        GameObject babyObstacle = Instantiate(obstacles[1], location.position, Quaternion.Euler(0, 0, 0));
        babyObstacle.AddComponent<Obstacles>();
        babyObstacle.tag = "Obstacle";
        obsSpawn.Add(babyObstacle);
        babyObstacle.transform.parent = obsCloneHolder.transform;
    }
    void SpawnMid(Transform location)
    {
        GameObject babyObstacle = Instantiate(obstacles[2], location.position, Quaternion.Euler(0, 0, 0));
        babyObstacle.AddComponent<Obstacles>();
        babyObstacle.tag = "Obstacle";
        obsSpawn.Add(babyObstacle);
        babyObstacle.transform.parent = obsCloneHolder.transform;
    }
}

