using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    public GameObject Player;
    public Transform PlayerPos;
    public GameObject currentPlatformType;
    public GameObject SpikePlatform, DuckPlatform, HalfNotePlatform, QuarterNoteRhythmPlatform, TwoEighthNotePlat1, TwoEighthNotePlat2, TwoEightNotePlat2, QuarterEighth1, QuarterEighth2, TripleChoice, DoubleChoice;
    public float newXposition;
    public GameObject[] PlatformTypes;
    public static float yPosition = -2;
    // Start is called before the first frame update
    void Awake()
    {
        PlatformTypes = new GameObject[] { SpikePlatform, DuckPlatform, TripleChoice, DoubleChoice, HalfNotePlatform, QuarterNoteRhythmPlatform, TwoEighthNotePlat1, TwoEighthNotePlat2, TwoEightNotePlat2, QuarterEighth1, QuarterEighth2 };

        newXposition = 0;
        PlayerPos = Player.transform;
        InvokeRepeating("SpawnPlatforms", 0, 50 * Time.deltaTime);   

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPlatforms()
    {
        int i = Random.Range(0, 2);
        if (i == 0)
        {
            i = Random.Range(0, 4);
        }
        else
        {
            i = Random.Range(4, 11);
        }
        currentPlatformType = PlatformTypes[i];
        Instantiate(currentPlatformType, new Vector2((newXposition - 2.5f), yPosition), Quaternion.identity);
        if (i == 2 || i == 3)
            newXposition += 20f;
        else
            newXposition += 10f;
    }
}
