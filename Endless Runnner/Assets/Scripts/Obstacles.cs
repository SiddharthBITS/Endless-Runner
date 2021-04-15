using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Obstacles : MonoBehaviour
{
    public float obSpeed = 0.05f;
    public float destroyRange = 10f;
    public GameObject obsSpawner;
    

    public int obsScore = 1;

    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-obSpeed, 0f, 0f), ForceMode.VelocityChange);
        
        if (gameObject.transform.position.x <= -destroyRange)
        {
                obsSpawner = GameObject.FindGameObjectWithTag("ObsSpawner");
                obsSpawner.GetComponent<ObstaclesSpawner>().obsSpawn.Remove(gameObject);
                obsSpawner.GetComponent<ObstaclesSpawner>().score += obsScore;
                Destroy(gameObject);
        }
        
    }
}
