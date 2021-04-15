using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource intro;
    public AudioSource loop;

    void Start()
    {
        float i = intro.clip.length;
        Invoke("Loop", i);
    }

    void Loop()
    {
            loop.Play(); 
    } 
}
