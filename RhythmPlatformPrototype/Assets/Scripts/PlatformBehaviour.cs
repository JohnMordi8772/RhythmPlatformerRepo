using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Awake()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
       if(transform.position.x == Player.transform.position.x - 16)
        {
            Destroy(gameObject);
        }
    }
}
