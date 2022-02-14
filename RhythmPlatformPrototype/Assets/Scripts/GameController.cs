using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float tempo;
    public float currentSpeed;
    public float missPenalty;
    public float correctBonus;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Monitoring(bool correct)
    {
        if (correct)
        {
            currentSpeed += correctBonus;
        }
        else
        {
            currentSpeed -= missPenalty;
        }
    }
}
