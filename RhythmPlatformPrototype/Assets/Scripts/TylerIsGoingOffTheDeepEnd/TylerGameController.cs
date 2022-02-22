using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TylerGameController : MonoBehaviour
{
    public int tempo = 120; //bpm
    public float currentSpeed = 1f;
    public float missPenalty;
    public float correctBonus;
    public GameObject Camera;
    public AudioClip correctSound;
    public AudioClip wrongSound;
    public GameObject ArrowSpawner;
    public int i;
    //yes, this was unfortunately necessary
    public AudioClip A2, A3, A4, B2, B3, B4, C3, C4, C5, D3, D4, D5, E3, E4, F3, F4, G3, G4, Ab3, Ab4, Bb2, Bb3, Bb4, Db3, Db4, Db5, Eb3, Eb4, Gb3, Gb4;

    public int[] mapObjectArray;
    public AudioClip[] mapSoundArray;

    public int currentArrow; //1 = up, 2 = down, 3 = left, 4 = right
    public AudioClip currentSound;
    public bool timeToChange;
    public void Awake()
    {
        mapSoundArray = new AudioClip[16] { D4, D4, D5, null, A4, null, null, Ab4, null, G4, null, F4, null, D4, F4, G4};
        mapObjectArray = new int[16]      {  3,  3,  1,    0,  2,    0,    0,   4,    0,  2,    0,  3,    0,  2,  1,  4};
      //  missPenalty = .05f;
       // correctBonus = .05f;
       // mtb = Camera.GetComponent<MetronomeBehaviour>();
    }
    private void Start()
    {
        
    }
    void Update()
    {
        if(i > 15)
        {
            i = 0;
        }
        ChangeSoundandMapGen();
    }

    void SpawnArrow()
    {
        Instantiate(ArrowSpawner, new Vector2(15.8f, 0), Quaternion.identity);
    }

    void ChangeSoundandMapGen()
    {
       
        
            for(i=0; i<15; )
            {
                if(timeToChange == true)
                {
                    currentSound = mapSoundArray[i];
                    currentArrow = mapObjectArray[i];
                    i++;
                    timeToChange = false;
                }
                
            }
       
        
    }

    public void Monitoring(bool correct)
    {
        
        if (correct)
        {
            AudioSource.PlayClipAtPoint(currentSound, Camera.transform.position);
            
          /*  if (Time.timeScale < 1.25f)
            {
                Time.timeScale += correctBonus;
                mtb.tempo += (correctBonus / 2);
            }
            print(Time.timeScale); */
        }
        else
        {
           /* if (Time.timeScale > 0.75f)
            {
                Time.timeScale -= missPenalty;
                print(Time.timeScale);
                mtb.tempo -= (missPenalty / 2);
            }
           */
            AudioSource.PlayClipAtPoint(wrongSound, Camera.transform.position);
        }


    }
}
