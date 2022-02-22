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

    public int[] mapObjectArray;
    public AudioClip[] mapSoundArray;

    public int currentArrow; //1 = up, 2 = down, 3 = left, 4 = right 
    public AudioClip currentSound;


    public bool noArrow;

    public void Awake()
    {

        //This maps 
        mapSoundArray = new AudioClip[64] { D4, D4, D5, null, A4, null, null, Ab4, null, G4, null, F4, null, D4, F4, G4, 
            C4, C4, D5, null, A4, null, null, Ab4, null, G4, null, F4, null, D4, F4, G4, 
            B3, B3, D5, null, A4, null, null, Ab4, null, G4, null, F4, null, D4, F4, G4, 
            Bb3, Bb3, D5, null, A4, null, null, Ab4, null, G4, null, F4, null, D4, F4, G4 };
        //null are pauses, The rest are musical notes


        //this maps arrows and obstacles in eighth note increments
        mapObjectArray = new int[64]      {  3,  3,  1,    0,  2,    0,   5,   4,    0,  2,    5,  3,    0,  2,  1,  4, 
            2, 2, 1, 0, 3, 0, 5, 4, 0, 2, 5, 3, 0, 2, 1, 4, 
            3, 3, 1, 0, 2, 0, 5, 4, 0, 2, 5, 3, 0, 2, 1, 4, 
            2, 2, 1, 0, 3, 0, 5, 4, 0, 2, 5, 3, 0, 2, 1, 4 };
        // 0 = spike 1 = up, 2 = down, 3 = left, 4 = right, 5 = nothing

      //  missPenalty = .05f;
       // correctBonus = .05f;
       // mtb = Camera.GetComponent<MetronomeBehaviour>();
    }
    private void Start()
    {
        //this starts as the arrows begin to spawn
        InvokeRepeating("TimeToChangeArrowTrue", 4f, .25f);

        //this starts as the first arrow gets to the player.
        InvokeRepeating("TimeToChangeSoundTrue", 5.5f, .25f);

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
        
        currentArrow = mapObjectArray[i];
    }

    void SpawnArrow()
    {
        Instantiate(ArrowSpawner, new Vector2(15.8f, 0), Quaternion.identity);
    }

    

    void TimeToChangeArrowTrue()
    {
        i++;
    }
    void TimeToChangeSoundTrue()
    {
        j++;
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
