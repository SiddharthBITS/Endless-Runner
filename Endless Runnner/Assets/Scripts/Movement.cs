using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public bool start = true;
    Rigidbody rb;
    bool isUp = false;
    bool isDown = false;
    int lane = 1;

    float colliderHeight;
    float colliderRadius;
    Vector3 colliderCenter;

    public float sideSpeed;
    public float rollColliderHeight;
    public float rollColliderRadius;
    public Vector3 rollColliderCenter;
    public float upForce = 10f;
    public Animator animator;
    public static Transform targetLeft;
    public static Transform targetMid;
    public static Transform targetRight;
    public Transform[] targets = { targetLeft, targetMid, targetRight };

    public Text cg;
    public Text score;
    public int[] cutoffs = { 500, 400, 300, 200, 150, 100, 50};
    public GameObject obsSpawner;
    public GameObject toBeDestroyed1;
    public GameObject toBeDestroyed2;
    public GameObject endScreen;

    public GameObject movement;
    public GameObject nab;
    public GameObject nabSpawner;
    public GameObject[] startObs;
    public GameObject scoreDisplay1;
    public GameObject scoreDisplay2;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        colliderHeight = gameObject.GetComponent<CapsuleCollider>().height;
        colliderRadius = gameObject.GetComponent<CapsuleCollider>().radius;
        colliderCenter = gameObject.GetComponent<CapsuleCollider>().center;
    }

    // Update is called once per frame
    void Update()
    {
        if(start)
        {
            animator.SetBool("isRunning", true);
            if (Input.GetKeyDown(KeyCode.D) && lane <= 1)
                {
                    StartCoroutine(MoveRight());
                }

            if (Input.GetKeyDown(KeyCode.A) && lane >= 1)
                {
                    StartCoroutine(MoveLeft());
                }

            if (Input.GetKeyDown(KeyCode.W) && !isUp && !isDown)
                {
                    StartCoroutine(Jump());
                }

            if (Input.GetKeyDown(KeyCode.S) && !isUp && !isDown)
                {
                    StartCoroutine(Roll());
                }
        }

        if(transform.position.x < 4)
        {
            GameOver();
        }
    }

    IEnumerator MoveRight()
    {
        animator.SetBool("right", true);
        while (gameObject.transform.position != targets[lane + 1].position)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targets[lane + 1].position, Time.deltaTime * sideSpeed);
            yield return new WaitForEndOfFrame();
        }
        animator.SetBool("right", false);
        lane++;    
    }

    IEnumerator MoveLeft()
    {
        animator.SetBool("left", true);
        while (gameObject.transform.position != targets[lane - 1].position)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targets[lane - 1].position, Time.deltaTime * sideSpeed);
            yield return new WaitForEndOfFrame();
        }
        animator.SetBool("left", false);
        lane--;  
    }

    IEnumerator Jump()
    {
        animator.SetBool("jump", true);
        isUp = true;
        rb.AddForce(new Vector3(0f, upForce, 0f), ForceMode.Impulse);
        yield return new WaitForSeconds(0.75f);
        animator.SetBool("jump", false);
        isUp = false;
    }

    IEnumerator Roll()
    {
        animator.SetBool("roll", true);
        isDown = true;

        gameObject.GetComponent<CapsuleCollider>().height = rollColliderHeight;
        gameObject.GetComponent<CapsuleCollider>().radius = rollColliderRadius;
        gameObject.GetComponent<CapsuleCollider>().center = rollColliderCenter;
        yield return new WaitForSeconds(0.75f);
        animator.SetBool("roll", false);
        isDown = false;
        gameObject.GetComponent<CapsuleCollider>().height = colliderHeight;
        gameObject.GetComponent<CapsuleCollider>().radius = colliderRadius;
        gameObject.GetComponent<CapsuleCollider>().center = colliderCenter;
    }

    void GameOver()
    {
        endScreen.SetActive(true);
        scoreDisplay1.SetActive(false);
        scoreDisplay2.SetActive(false);
        toBeDestroyed1.SetActive(false);
        toBeDestroyed2.SetActive(false);
        if (obsSpawner.GetComponent<ObstaclesSpawner>().score >= cutoffs[0])
        {
            cg.text = "A";
            scoreDisplay1.SetActive(true);
            scoreDisplay2.SetActive(true);
            score.text = obsSpawner.GetComponent<ObstaclesSpawner>().score.ToString();
        }
        else if (obsSpawner.GetComponent<ObstaclesSpawner>().score >= cutoffs[1])
        {
            cg.text = "A-";
        }
        else if (obsSpawner.GetComponent<ObstaclesSpawner>().score >= cutoffs[2])
        {
            cg.text = "B";
        }
        else if (obsSpawner.GetComponent<ObstaclesSpawner>().score >= cutoffs[3])
        {
            cg.text = "B-";
        }
        else if (obsSpawner.GetComponent<ObstaclesSpawner>().score >= cutoffs[4])
        {
            cg.text = "C";
        }
        else if (obsSpawner.GetComponent<ObstaclesSpawner>().score >= cutoffs[5])
        {
            cg.text = "C-";
        }
        else if (obsSpawner.GetComponent<ObstaclesSpawner>().score >= cutoffs[6])
        {
            cg.text = "D";
        }
        else
        {
            cg.text = "NC";
        }

        movement.GetComponent<Movement>().start = false;
        nab.GetComponent<NAB>().start = false;
        nabSpawner.GetComponent<NABSpawner>().start = false;
        obsSpawner.GetComponent<ObstaclesSpawner>().start = false;
        foreach (GameObject obs in startObs)
        {
            if (obs != null)
            {
                obs.SetActive(false);
            }
        }
        foreach(GameObject ob in obsSpawner.GetComponent<ObstaclesSpawner>().obsSpawn)
        {
            Destroy(ob);
        }
    }
}
