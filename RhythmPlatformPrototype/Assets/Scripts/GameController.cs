using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float currentSpeed = 1f;
    public float missPenalty;
    public float correctBonus;
    public GameObject Camera;
    public AudioClip correctSound;

    public void Awake()
    {
        missPenalty = .05f;
        correctBonus = .05f;
    }
    public void Monitoring(bool correct)
    {
        if (correct)
        {
            AudioSource.PlayClipAtPoint(correctSound, Camera.transform.position);
            if(Time.timeScale < 1.5f)
            {
                Time.timeScale += correctBonus;
            }
            print(Time.timeScale);
        }
        else
        {
            if(Time.timeScale > 0.5f)
            {
                Time.timeScale -= missPenalty;
                print(Time.timeScale);
            }
            
        }

        
    }
}
