using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    public GameObject Player;
    public Transform PlayerPos;
    public GameObject currentPlatformType;
    public GameObject SpikePlatform, DuckPlatform, HalfNotePlatform, QuarterNoteRhythmPlatform, TwoEighthNotePlat1, TwoEighthNotePlat2, TwoEightNotePlat2, QuarterEighth1, QuarterEighth2;
    public int newXposition;

    // Start is called before the first frame update
    void Awake()
    {
        newXposition = 0;
        PlayerPos = Player.transform;
        InvokeRepeating("SpawnPlatforms", 0, 20 * Time.deltaTime);   

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPlatforms()
    {
        Instantiate(currentPlatformType, new Vector2(newXposition, -2), Quaternion.identity);
        newXposition += 8;
    }
}
