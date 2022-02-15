using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float currentSpeed = 1f;
    public float missPenalty;
    public float correctBonus;

    public void Monitoring(bool correct)
    {
        if (correct)
        {
            Time.timeScale += correctBonus;
        }
        else
        {
            Time.timeScale -= missPenalty;
        }
    }
}
