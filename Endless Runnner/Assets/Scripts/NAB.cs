using System.Collections.Generic;
using UnityEngine;

public class NAB : MonoBehaviour
{
    public bool start;
    public float nabSpeed = 300f;
    public List<GameObject> nabs = new List<GameObject>();
    
    void Update()
    {
        if (start)
        {
            for (int i = 0; i < nabs.Count; i++)
            {
                nabs[i].GetComponent<Rigidbody>().AddForce(new Vector3(-nabSpeed, 0f, 0f), ForceMode.VelocityChange);
            }
        }
    }
}
