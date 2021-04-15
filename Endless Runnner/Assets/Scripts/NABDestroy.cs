using UnityEngine;

public class NABDestroy : MonoBehaviour
{
    public float destroyRange = 10f;
    public GameObject list;
    public bool start;

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x <= -destroyRange)
        {
            list = GameObject.FindGameObjectWithTag("List");
            list.GetComponent<NAB>().nabs.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
