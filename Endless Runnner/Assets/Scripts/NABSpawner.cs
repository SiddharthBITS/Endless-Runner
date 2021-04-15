using UnityEngine;

public class NABSpawner : MonoBehaviour
{
    public GameObject[] r;
    public GameObject[] l;
    public GameObject list;
    public GameObject cloneHolder;
    public Transform rLoc;
    public Transform lLoc;
    public float spawnEvery = 2f;
    float time;
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
            int lCount = Random.Range(0, 4);
            int rCount = Random.Range(0, 4);

            GameObject babyNabR = Instantiate(r[rCount], rLoc.position, Quaternion.Euler(0,0,0));
            list.GetComponent<NAB>().nabs.Add(babyNabR);
            babyNabR.AddComponent<NABDestroy>();
            babyNabR.transform.parent = cloneHolder.transform;

            GameObject babyNabL = Instantiate(l[lCount], lLoc.position, Quaternion.Euler(0, 0, 0));
            list.GetComponent<NAB>().nabs.Add(babyNabL);
            babyNabL.AddComponent<NABDestroy>();
            babyNabL.transform.parent = cloneHolder.transform;

            time = spawnEvery;
        }
    }
}
