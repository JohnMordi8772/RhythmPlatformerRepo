using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    public GameObject Player;
    public Transform PlayerPos;
    public GameObject currentPlatformType;
    public GameObject SpikePlatform, DuckPlatform, HalfNotePlatform, QuarterNoteRhythmPlatform, TwoEighthNotePlat1, TwoEighthNotePlat2, TwoEightNotePlat2, QuarterEighth1, QuarterEighth2;
    public float newXposition;
    public GameObject[] PlatformTypes;
    // Start is called before the first frame update
    void Awake()
    {
        PlatformTypes = new GameObject[] { SpikePlatform, DuckPlatform, HalfNotePlatform, QuarterNoteRhythmPlatform, TwoEighthNotePlat1, TwoEighthNotePlat2, TwoEightNotePlat2, QuarterEighth1, QuarterEighth2 };

        newXposition = 0;
        PlayerPos = Player.transform;
        InvokeRepeating("SpawnPlatforms", 0, 50 * Time.deltaTime);   

    }

    // Update is called once per frame
    void Update()
    {
        int i = Random.Range(0, 2); 
        if(i == 0)
        {
            i = Random.Range(0, 2);
        }
        else
        {
            i = Random.Range(2, 9);
        }
        currentPlatformType = PlatformTypes[i];
    }

    void SpawnPlatforms()
    {
        Instantiate(currentPlatformType, new Vector2((newXposition - 2.5f), -2), Quaternion.identity);
        newXposition += 10f;
    }
}
