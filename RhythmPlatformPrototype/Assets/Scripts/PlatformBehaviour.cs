using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    public float tempo;
    public float moveSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        tempo = 60;
        moveSpeed = tempo/30;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
}
