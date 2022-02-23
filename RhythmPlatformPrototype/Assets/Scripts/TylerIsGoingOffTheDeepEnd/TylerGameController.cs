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
    public int i, j;

    //yes, this was unfortunately necessary
    public AudioClip A2, A3, A4, B2, B3, B4, C3, C4, C5, D3, D4, D5, E3, E4, F3, F4, G3, G4, Ab3, Ab4, Bb2, Bb3, Bb4, Db3, Db4, Db5, Eb3, Eb4, Gb3, Gb4;

    public int[] bpm100mapObjectArray;
    public int[] bpm90mapObjectArray;
    public int[] bpm120mapObjectArray;
    public AudioClip[] mapSoundArray;

    public int currentArrow; //1 = up, 2 = down, 3 = left, 4 = right 
    public AudioClip currentSound;

    public AudioClip metronomeSound;
    public bool noArrow;
   
    public float bpm;

    public int currentArray;
    public void Awake()
    {
        bpm = 100;
        
        InvokeRepeating("Metronome", 0, (60 / bpm) );


        //This maps 
        mapSoundArray = new AudioClip[64] { B4, null, A4, null, G4, null, A4, null, B4, null, B4, null, B4, null, null, null,
             A4, null, A4, null, A4, null, null, null,  B4, null, D5, null, D5, null, null, null,
            B4, null, A4, null, G4, null, A4, null, B4, null, B4, null, B4, null, B4, null, 
            A4, null, A4, null, B4, null, A4, null, G4, null, null, null, null, null, null, null };
        //null are pauses, The rest are musical notes


        //this maps arrows and obstacles in eighth note increments
        bpm100mapObjectArray = new int[64]      {  1,  5,  4,    5,  2,    5,   4,   5,   3 ,  5,    3,  5,    3,  5,  0,  5,
            2 ,  5,    2,  5,    2,  5,  0,  5, 3 ,  5,    1,  5,    1,  5,  0,  5,
             1,  5,  4,    5,  2,    5,   4,   5,   3 ,  5,    3,  5,    3,  5, 3, 5, 
            2, 5, 2, 5, 3, 5, 4, 5, 2, 5, 0, 5, 5, 5, 6, 5 };
        bpm120mapObjectArray = new int[64]      {  1,  0,  4,    5,  2,    7,   4,   5,   3 ,  5,    3,  5,    3,  5,  0,  5,
            2 ,  5,    2,  7,    2,  5,  0,  5, 3 ,  5,    1,  5,    1,  5,  0,  5,
             1,  5,  4,    5,  2,    5,   4,   5,   3 ,  5,    3,  5,    3,  5, 3, 5,
            2, 5, 2, 5, 3, 5, 4, 5, 2, 5, 0, 5, 5, 5, 6, 5 };
        bpm90mapObjectArray = new int[64]      {  1,  7,  4,    5,  2,    5,   0,   5,   3 ,  5,    3,  5,    3,  5,  0,  5,
            2 ,  5,    2,  5,    2,  5,  0,  5, 3 ,  5,    1,  5,    1,  5,  0,  5,
             1,  5,  4,    0,  2,    5,   4,   5,   3 ,  7,    3,  5,    3,  5, 3, 5,
            2, 0, 2, 5, 3, 5, 4, 5, 2, 5, 7, 5, 0, 5, 6, 5 };
        // 0 = spike 1 = up, 2 = down, 3 = left, 4 = right, 5 = nothing

        //  missPenalty = .05f;
        // correctBonus = .05f;
        // mtb = Camera.GetComponent<MetronomeBehaviour>();
    }
    private void Start()
    {
      /*
        //this starts as the arrows begin to spawn
        InvokeRepeating("TimeToChangeArrowTrue", 4f, 30/bpm);
      */
        //this starts as the first arrow gets to the player.
        InvokeRepeating("TimeToChangeSoundTrue", 5.5f, 30/bpm);
      
    }
    void Update()
    {
        if(i > 63)
        {
            i = 0;
            
        }
        if (j > 63)
        {
            j = 0;
        }
        
        currentSound = mapSoundArray[j];

        //this is a failsafe to avoid NullReferenceExceptionErrors
        if(mapSoundArray[j] == null)
        {
            currentSound = mapSoundArray[j - 1];
        }    
        
        if(bpm == 100)
        {
            currentArrow = bpm100mapObjectArray[i];
        }
        else if (bpm == 120)
        {
            currentArrow = bpm120mapObjectArray[i];
        }
        else if (bpm == 90)
        {
            currentArrow = bpm90mapObjectArray[i];
        }




    }

    void SpawnArrow()
    {
        Instantiate(ArrowSpawner, new Vector2(15.8f, 0), Quaternion.identity);
    }

    /*

    void TimeToChangeArrowTrue()
    {
        i++;
    }
    */
    void TimeToChangeSoundTrue()
    {
        j++;
    }
    

    void Metronome()
    {
        AudioSource.PlayClipAtPoint(metronomeSound, Camera.transform.position);

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
          
        }


    }
}
