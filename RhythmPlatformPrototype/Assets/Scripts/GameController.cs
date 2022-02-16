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
    public AudioClip wrongSound;
    public MetronomeBehaviour mtb;

    public void Awake()
    {
        missPenalty = .05f;
        correctBonus = .05f;
        mtb = Camera.GetComponent<MetronomeBehaviour>();
    }
    public void Monitoring(bool correct)
    {
        if (correct)
        {
            AudioSource.PlayClipAtPoint(correctSound, Camera.transform.position);
            if(Time.timeScale < 1.25f)
            {
                Time.timeScale += correctBonus;
                mtb.tempo += (correctBonus / 2);
            }
            print(Time.timeScale);
        }
        else
        {
            if(Time.timeScale > 0.75f)
            {
                Time.timeScale -= missPenalty;
                print(Time.timeScale);
                mtb.tempo -= (missPenalty / 2);
            }
            AudioSource.PlayClipAtPoint(wrongSound, Camera.transform.position);
        }

        
    }
}
