using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float currentSpeed = 1f;
    public float missPenalty;
    public float correctBonus;

    public float bpm;
    public float upb;

    public PlayerBehaviour pb;
    public GameObject Camera;
    public AudioClip correctSound;
    public AudioClip wrongSound;
    public MetronomeBehaviour mtb;

    public void Awake()
    {
        pb = GameObject.Find("Player").GetComponent<PlayerBehaviour>();
        bpm = 120f;
        upb = 5f;
        pb.moveSpeed = (upb * bpm) / 60f;
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
                mtb.tempo += correctBonus;
            }
            print(Time.timeScale);
        }
        else
        {
            if(Time.timeScale > 0.75f)
            {
                Time.timeScale -= missPenalty;
                print(Time.timeScale);
                mtb.tempo -= missPenalty;
            }
            AudioSource.PlayClipAtPoint(wrongSound, Camera.transform.position);
        }

        
    }
}
