using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MetronomeBehaviour : MonoBehaviour
{
    public float tempo;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        tempo = 1;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.pitch = tempo;

    }
}
